import React, { useState, useEffect } from "react";
import { FormGroup, Label, Input, Form, Button } from "reactstrap";
import axios from "axios";
import { useParams, Link } from "react-router-dom";

export default function EditEmployees() {
  const [formValue, setformValue] = useState({
    FirstName: "",
    LastName: "",
  });
  const { id } = useParams();

  const handleChange = (event) => {
    setformValue({
      ...formValue,
      [event.target.name]: event.target.value,
    });
  };

  useEffect(() => {
    axios.get(`https://localhost:44302/api/employee/${id}`).then((res) => {
      setformValue(res.data);
    });
  }, [id]);

  const handleSubmit = () => {
    axios
      .put(`https://localhost:44302/api/employee/edit/${id}`, {
        FirstName: formValue.FirstName,
        LastName: formValue.LastName,
      })
      .then((response) => {
        console.log(response);
      });
  };

  return (
    <div>
      <Link class="badge-primary" to="/">
        Home
      </Link>
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
        <Button color="success" size="">
          Edit
        </Button>
      </Form>
    </div>
  );
}
