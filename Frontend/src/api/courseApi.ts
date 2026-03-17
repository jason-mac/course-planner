import type { Course } from '../types';
import type { CourseQuery } from '../types';

const baseUrl = 'http://localhost:5001/api';

export async function fetchCourses(query?: CourseQuery): Promise<Course[]> {
  const params = new URLSearchParams();
  const keys = Object.keys(query || {}) as (keyof CourseQuery)[];
  keys.forEach((key) => {
    if (query?.[key]) params.append(key, String(query[key]));
  });

  const res = await fetch(`${baseUrl}/courses`);
  if (!res.ok) throw new Error('Failed to fetch courses');
  return res.json();
}

export async function fetchCourseById(id: number): Promise<Course[]> {
  const res = await fetch(`${baseUrl}/courses/${id}`);
  if (!res.ok) throw new Error('Failed to fetch courses');
  return res.json();
}
