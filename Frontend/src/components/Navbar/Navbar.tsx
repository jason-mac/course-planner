import "./Navbar.css";

function Navbar() {
  return (
    <header className="navbar">
      <div className="navbar__inner">
        <a className="navbar__brand" href="/">
          UBC Course Planner
        </a>

        <nav className="navbar__nav" aria-label="Primary">
          <a className="navbar__link" href="/calendar">
            Calendar
          </a>
          <a className="navbar__link" href="/courses">
            Courses
          </a>
        </nav>
      </div>
    </header>
  );
}

export default Navbar;
