import { useEffect, useState } from "react";
import axios from "../api/axios";
import TaskItem from "../features/tasks/TaskItem";

interface Task {
  id: number;
  title: string;
  description: string;
  isCompleted: boolean;
}

const Dashboard = () => {
  const [tasks, setTasks] = useState<Task[]>([]);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    const fetchTasks = async () => {
      try {
        const res = await axios.get("/tasks");
        setTasks(res.data);
      } catch (err) {
        console.error("Erreur lors du chargement des tâches", err);
      } finally {
        setLoading(false);
      }
    };

    fetchTasks();
  }, []);

  if (loading) return <p>Chargement...</p>;

  return (
    <div>
      <h1>Dashboard - Liste des tâches</h1>
      {tasks.length === 0 ? (
        <p>Aucune tâche à afficher</p>
      ) : (
        tasks.map((task) => <TaskItem key={task.id} task={task} />)
      )}
    </div>
  );
};

export default Dashboard;
