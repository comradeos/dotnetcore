import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HelloWorld from './pages/HelloWorld';


function App() {
    return (
        <Router>
            <Routes>
                <Route path="/hello" element={<HelloWorld />} />
                <Route path="/" element={<div>lol</div>} />
            </Routes>
        </Router>
  );
}

export default App;
