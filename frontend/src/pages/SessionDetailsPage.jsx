import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import * as signalR from '@microsoft/signalr';
import SessionDetailsTable from '../components/SessionDetailsTable';

const SessionDetailsPage = () => {
    const { sessionId } = useParams();
    const [session, setSession] = useState(null);

    useEffect(() => {
        const connection = new signalR.HubConnectionBuilder()
            .withUrl(`http://localhost:5078/session-detail?sessionId=${sessionId}`)
            .withAutomaticReconnect()
            .build();

        connection.on("SessionDetailUpdate", (sessionDetail) => {
            if (sessionDetail.sessionId === sessionId) {
                setSession(sessionDetail);
            }
        });

        connection.start()
            .then(() => {
                console.log("Connected to session-detail WebSocket");
            })
            .catch((err) => {
                console.error("WebSocket connection error:", err);
            });

        return () => {
            connection.stop();
            console.log("Disconnected from session-detail WebSocket");
        };
    }, [sessionId]);

    return (
        <div className="container mt-4">
            <h2 className="mb-4">Session Details</h2>
            {session ? (
                <SessionDetailsTable competitors={session?.competitors || []} />
            ) : (
                <p>Waiting for session data...</p>
            )}
        </div>
    );
};

export default SessionDetailsPage;