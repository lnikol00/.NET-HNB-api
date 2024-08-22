import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import Input from "./pages/Input";
import Values from "./pages/Values";


function App() {
  return (
    <div className='font-[Quicksand] bg bg-gradient-to-t from-[#63e5ff] to-[#b1f2ff] h-screen'>
      <Router>
        <Routes>
          <Route index element={<Input />} />
          <Route path='values' element={<Values />} />
        </Routes>
      </Router>
    </div>
  );
}

export default App;
