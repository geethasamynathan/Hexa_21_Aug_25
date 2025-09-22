import logo from "./logo.svg";
import "./App.css";
import Header from "./Header";
import ProfilePage from "./ProfilePage";
import { UserContext } from "./UserContext";

function App() {
  const userInfo = {
    name: "Test user",
    avatarUrl: "https://i.pravatar.cc/150?u=aarav",
  };
  return (
    <UserContext.Provider value={userInfo}>
      <Header />
      <ProfilePage />
    </UserContext.Provider>
  );
}

export default App;
