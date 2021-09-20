import React, { Component } from "react";
import SignIn from "./Component/SignIn";
import Register from "./Component/Register";
import ListVote from "./Component/ListVote";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = { mode: "login" }
    this.changeMode = this.changeMode.bind(this);

  }
  componentDidMount() {
    let dataLocal = localStorage.getItem('sample-vote');
    if (dataLocal) {
      dataLocal = JSON.parse(dataLocal);
      if (new Date(dataLocal.expiration) > new Date()) {
        this.setState({ mode: "listVote" });
      }
      else {
        this.setState({ mode: "login" });
      }
    }
    ;
  }
  changeMode(e) {
    if (e === "login") {
      this.setState({ mode: "register" });
    }
    else if (this.state.mode === "register") {
      this.setState({ mode: "login" });
    }
    else {
      this.setState({ mode: "listVote" });
    }
  }
  render() {

    if (this.state.mode === "login") {
      return <SignIn action={this.changeMode} />
    }
    else if (this.state.mode === "register") {
      return <Register action={this.changeMode} />
    }
    else {
      return <ListVote action={this.changeMode} />
    }
  }
}

