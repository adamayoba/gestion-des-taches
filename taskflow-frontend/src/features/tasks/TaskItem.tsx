import React from "react";

interface Task {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
}

const TaskItem = ({ task }: { task: Task }) => {
  return (
    <div style={{ border: "1px solid #ccc", padding: "1rem", margin: "1rem 0" }}>
      <h3>{task.title}</h3>
      <p>{task.description}</p>
    </div>
  );
};

export default TaskItem;
