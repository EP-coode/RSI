import React, { useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import { CarsView } from "./views/CarsView";
import "antd/dist/antd.css";

function App() {
  return (
    <div className="App">
      <CarsView />
    </div>
  );
}

export default App;
