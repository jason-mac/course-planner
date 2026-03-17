import { useState, useEffect } from 'react';
import type { Course } from './types';
import Navbar from './components/layout/Navbar';
import Footer from './components/layout/Footer';
import ScheduleGrid from './components/schedule/ScheduleGrid';
import Sidebar from './components/layout/Sidebar';
import { fetchCourses } from './api';

function App() {
  const [courses, setCourses] = useState<Course[]>([]);
  const loadCourses = () => fetchCourses().then((data) => setCourses(data));

  useEffect(() => {
    fetchCourses().then((data) => setCourses(data));
  }, []);

  return (
    <div className="min-h-screen flex flex-col bg-gray-200">
      <Navbar />
      <main className="flex flex-1 p-1">
        <Sidebar courses={courses} onRefresh={loadCourses} />
        <ScheduleGrid />
      </main>
      <Footer />
    </div>
  );
}

export default App;
