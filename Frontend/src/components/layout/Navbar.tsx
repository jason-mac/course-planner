function Navbar() {
  return (
    <nav className="flex justify-between items-center px-6 py-4 bg-sky-300 rounded-b-xl">
      <h1 className="text-xl font-bold">UBC Course Planner</h1>
      <ul className="flex gap-3 list-none">
        <li>
          <button className="text-white border border-white/50 rounded-lg px-4 py-1.5 text-sm hover:bg-white/20 transition cursor-pointer">
            About
          </button>
        </li>
        <li>
          <button className="text-white border border-white/50 rounded-lg px-4 py-1.5 text-sm hover:bg-white/20 transition cursor-pointer">
            Contact
          </button>
        </li>
      </ul>
    </nav>
  );
}
export default Navbar;
