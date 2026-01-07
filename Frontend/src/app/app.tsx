import Calendar from "../components/Calendar/Calendar.tsx";
import Navbar from "../components/Navbar/Navbar.tsx";
import "./App.css";

function App() {
  return (
    <>
      <Navbar />
      <main>
        <Calendar />
      </main>
    </>
  );
}

export default App;
