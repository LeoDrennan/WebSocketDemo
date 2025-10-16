import SessionTable from './components/SessionTable';
import SessionDetailsPage from './pages/SessionDetailsPage';
import { Routes, Route } from 'react-router-dom';
import './App.css'

function App() {
    return (
        <Routes>
            <Route path="/" element={<SessionTable />} />
            <Route path="/sessions/:sessionId" element={<SessionDetailsPage />} />
        </Routes>
    );
}

export default App
