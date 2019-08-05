import React from "react";
import Header from "./common/Header";
import PageNotFound from "./NotFound";
import HomePage from "./home/HomePage";
import { Route, Switch } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import "react-toastify/dist/ReactToastify.css";
import "./font-awesome.css";

const App = () => {
  return (
      <div className="container-fluid">
        <Header />
        <Switch>
          <Route exact path="/" component={HomePage} />
          <Route component={PageNotFound} />
        </Switch>
        <ToastContainer autoClose={3000} hideProgressBar={true} />
      </div>
  );
};

export default App;