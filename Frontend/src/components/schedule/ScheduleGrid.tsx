const days: string[] = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri'];
const times: string[] = [];
for (let hour = 8; hour <= 21; hour++) {
  times.push(`${hour}:00`);
  if (hour < 21) times.push(`${hour}:30`);
}

function generateDay(day: string) {
  const border = day == 'Fri' ? null : 'border-r';
  const className = `${border} text-center font-bold text-gray-600 border-slate-400 pb-2`;
  return (
    <div key={day} className={className}>
      {day}
    </div>
  );
}

function generateTime(time: string) {
  const borderRight = (day: string) => (day == 'Fri' ? null : 'border-r');
  const borderBot = time == '21:00' ? null : 'border-b';
  return (
    <>
      <div key={time} className="p-2 text-sm text-gray-500 w-16">
        {time}
      </div>
      {days.map((day) => (
        <div
          key={day}
          className={`${borderRight(day)} ${borderBot} border-slate-400 p-2`}
        ></div>
      ))}
    </>
  );
}

function ScheduleGrid() {
  return (
    <div className="flex-1 m-2 p-4 bg-white rounded-xl">
      <div className="grid grid-cols-[4rem_repeat(5,1fr)]">
        <div></div>
        {days.map((day) => generateDay(day))}
        {times.map((time) => generateTime(time))}
      </div>
    </div>
  );
}

export default ScheduleGrid;
