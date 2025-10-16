import React from 'react';

const SessionDetailsTable = ({ competitors }) => {
    return (
        <table className="table table-sm table-bordered">
            <thead className="table-light">
                <tr>
                    <th>Pos</th>
                    <th>#</th>
                    <th>Name</th>
                    <th>Team</th>
                    <th>Class</th>
                    <th>Laps</th>
                    <th>Fastest Lap</th>
                    <th>Last Lap</th>
                </tr>
            </thead>
            <tbody>
                {competitors.map((c) => (
                    <tr key={c.id}>
                        <td>{c.result.position}</td>
                        <td>{c.startNumber}</td>
                        <td>{c.name}</td>
                        <td>{c.teamName}</td>
                        <td>{c.className}</td>
                        <td>{c.result.laps}</td>
                        <td>{c.result.fastestLapTime?.display || '-'}</td>
                        <td>{c.result.lastLapTime?.display || '-'}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default SessionDetailsTable;