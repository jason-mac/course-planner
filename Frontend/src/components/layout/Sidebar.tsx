import { useState } from 'react';
import type { Course } from '../../types';

interface SidebarProps {
  courses: Course[];
  onRefresh: () => void;
}

function Sidebar({ courses, onRefresh }: SidebarProps) {
  const [search, setSearch] = useState('');
  const [isOpen, setIsOpen] = useState(false);

  const filtered = courses.filter((course) =>
    `${course.subjectCode} ${course.courseNumber} ${course.title}`
      .toLowerCase()
      .includes(search.toLowerCase())
  );

  return (
    <aside className="w-64 bg-white p-4 flex flex-col gap-4 rounded-xl m-4 mt-2">
      <h2 className="font-bold text-lg">Course Planner</h2>
      <div className="relative">
        <input
          type="text"
          placeholder="Search Courses"
          value={search}
          onChange={(e) => {
            setSearch(e.target.value);
            setIsOpen(true);
          }}
          onFocus={() => setIsOpen(true)}
          onBlur={() => setTimeout(() => setIsOpen(false), 150)}
          className="border rounded p-2 w-full"
        />
        {isOpen && search && (
          <ul className="absolute z-10 bg-white border rounded mt-1 w-full max-h-48 overflow-y-auto shadow">
            {filtered.map((course) => (
              <li
                key={course.courseId}
                className="p-2 hover:bg-gray-100 cursor-pointer text-sm"
              >
                {course.subjectCode} {course.courseNumber} - {course.title}
              </li>
            ))}
          </ul>
        )}
      </div>
      <button className="bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition cursor-pointer">
        Generate Schedule
      </button>
      <button
        onClick={onRefresh}
        className="bg-blue-500 text-white py-2 rounded hover:bg-blue-600 transition cursor-pointer"
      >
        Refresh
      </button>
    </aside>
  );
}

export default Sidebar;
