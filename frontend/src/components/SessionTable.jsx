import React, { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';

const SessionTable = () => {
    const [sessions, setSessions] = useState([]);

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl("http://localhost:5078/sessions")
            .withAutomaticReconnect()
            .build();

        connection.on("SessionsUpdate", (sessions) => {
            setSessions(sessions);
        });

        connection.start()
            .then(() => {
                console.log("SignalR connected");
            })
            .catch((err) => {
                console.error("SignalR connection error:", err);
            });

        return () => {
            connection.stop();
            console.log("SignalR disconnected");
        };
    }, []);

    return (
        <div className="container mt-4">
            <h2 className="mb-4">Live Sessions</h2>
            <table className="table table-striped table-bordered">
                <thead className="table-light">
                    <tr>
                        <th>Session ID</th>
                        <th>Series</th>
                        <th>Name</th>
                        <th>Track</th>
                        <th>State</th>
                        <th>Start Time</th>
                        <th>Duration</th>
                    </tr>
                </thead>
                <tbody>
                    {sessions.map((session) => (
                        <tr key={session.sessionId}>
                            <td>{session.sessionId}</td>
                            <td>{session.series}</td>
                            <td>{session.name}</td>
                            <td>{session.track}</td>
                            <td>
                                <span className={`badge bg-${getStateColor(session.state)}`}>
                                    {session.state}
                                </span>
                            </td>
                            <td>{new Date(session.startTime).toLocaleString()}</td>
                            <td>{session.duration}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

function getStateColor(state) {
    switch (state.toLowerCase()) {
        case 'pending':
            return 'warning';
        case 'active':
            return 'success';
        case 'completed':
            return 'secondary';
        default:
            return 'light';
    }
}

export default SessionTable;
