import './App.css';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import HelloWorld from './pages/HelloWorld';


function App() {
    return (
        <Router>
            <nav>
                <Link to="/hello">Hello World</Link>
                <Link to="/">Main</Link>
            </nav>
            <Routes>
                <Route path="/hello" element={<HelloWorld />} />
                <Route path="/" element={<h1>Main</h1>} />
            </Routes>
        </Router>
  );
}

export default App;
