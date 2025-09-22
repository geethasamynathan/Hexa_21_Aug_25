import logo from "./logo.svg";
import "./App.css";
import Header from "./Header";
import ProfilePage from "./ProfilePage";
import { UserContext } from "./UserContext";
import SimpleForm from "./SimpleForm";
import RegistrationForm from "./RegistrationForm";
function App() {
  const userInfo = {
    name: "Test user",
    avatarUrl: "https://i.pravatar.cc/150?u=aarav",
  };
  return (
    <UserContext.Provider value={userInfo}>
      {/* <Header />
      <ProfilePage /> */}
      {/* <SimpleForm /> */}
      <RegistrationForm />
    </UserContext.Provider>
  );
}

export default App;
