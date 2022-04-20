import { useState, useEffect } from "react";
import axios from "axios";
import { Table, Button } from "reactstrap";
import { Link } from "react-router-dom";

export default function DataFetching() {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    axios.get("https://localhost:44302/api/employee").then((res) => {
      setEmployees(res.data);
    });
  }, []);

  const getData = () => {
    axios.get("https://localhost:44302/api/employee").then((res) => {
      setEmployees(res.data);
    });
  };

  const handleDelete = (id) => {
    axios.delete(`https://localhost:44302/api/employee/del/${id}`).then(() => {
      getData();
    });
  };

  return (
    <Table striped>
      <thead>
        <tr>
          <th>#</th>
          <th>First name</th>
          <th>Last Name</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        {employees.map((employee) => {
          return (
            <tr key={employee.Id}>
              <td>{employee.Id}</td>
              <td>{employee.FirstName}</td>
              <td>{employee.LastName}</td>
              <td>
              <Link to={`/edit/${employee.Id}`}>
                <Button color="success" size="small" className="mx-2">
                  Edit
                </Button>
                </Link>
                <Button
                  value={employee.Id}
                  onClick={() => handleDelete(employee.Id)}
                  color="danger"
                  size="small"
                  className="mx-2"
                >
                  Delete
                </Button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
}
