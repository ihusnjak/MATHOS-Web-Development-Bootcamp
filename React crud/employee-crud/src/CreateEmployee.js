import React, { useState } from "react";
import { FormGroup, Label, Input, Form, Button } from "reactstrap";
import axios from "axios";

export default function CreateEmployee() {
  const [formValue, setformValue] = useState({
    FirstName: "",
    LastName: "",
  });

  const handleChange = (event) => {
    setformValue({
      ...formValue,
      [event.target.name]: event.target.value,
    });
  };

  const handleSubmit = () => {
    axios
      .post("https://localhost:44302/api/employee", {
        FirstName: formValue.FirstName,
        LastName: formValue.LastName,
      })
      .then((response) => {
        console.log(response);
      });
  };

  return (
    <Form onSubmit={handleSubmit} autoComplete="off">
      <FormGroup>
        <Label for="firstName">First name</Label>
        <Input
          id="firstName"
          name="FirstName"
          value={formValue.FirstName}
          onChange={handleChange}
          placeholder="First name"
          type="text"
        />
      </FormGroup>
      <FormGroup>
        <Label for="lastName">Last name</Label>
        <Input
          id="lastName"
          name="LastName"
          value={formValue.LastName}
          onChange={handleChange}
          placeholder="Last Name"
          type="text"
        />
      </FormGroup>
      <Button color="success">Add new employee</Button>
    </Form>
  );
}
