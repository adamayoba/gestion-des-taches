import { useState } from "react";
import axios from "../api/axios";
import { useAuth } from "../auth/AuthContext";
import { useNavigate } from "react-router-dom";

const Login = () => {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const { login } = useAuth();
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const response = await axios.post("/Auth/login", { username, password });
      console.log(response.data.token); // Log the token for debugging
      login(response.data); 
      navigate("/dashboard");
    } catch (err) {
      console.error(err);
      alert("Échec de la connexion.");
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Connexion</h2>
      <input value={username} onChange={(e) => setUsername(e.target.value)} placeholder="Username" />
      <input value={password} type="password" onChange={(e) => setPassword(e.target.value)} placeholder="Password" />
      <button type="submit">Se connecter</button>
    </form>
  );
};

export default Login;
