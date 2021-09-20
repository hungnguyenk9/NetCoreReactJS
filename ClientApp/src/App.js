import React, { Component } from "react";
import SignIn from "./Component/SignIn";
import Register from "./Component/Register";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.state = {mode: "login"}
    this.changeMode = this.changeMode.bind(this,this.props.param);
  }
  changeMode(param){
    alert(param);
    // this.setState({mode: param})
  }
  render() {
    if (this.state.mode === "login") {
      return <SignIn action={this.changeMode}/>
    }
    else
    {
      return <Register action={this.changeMode}/>
    }
  }
}

