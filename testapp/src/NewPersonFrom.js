import { useState } from "react";

export default function NewPersonForm() {

    const [person, setPerson] = useState({ firstname: "", lastname: "", email: "" });
    
    const handleSubmit = (event) => {    
        event.preventDefault();
        console.log(person);
      };

    return (
        <div className="person-form">
            <form onSubmit={handleSubmit}>
                <label htmlFor="first-name">
                    First name
                    <input id="first-name"
                        onChange={(e) => setPerson(e.target.value)}
                        value={person.firstname}
                        placeholder="enter first name here" />
                </label>
                <label htmlFor="last-name">
                    Last name
                    <input id="last-name"
                        onChange={(e) => setPerson(e.target.value)}
                        value={person.lastname}
                        placeholder="enter last name here" />
                </label>
                <label htmlFor="email">
                    Email
                    <input id="email"
                        onChange={(e) => setPerson(e.target.value)}
                        value={person.email}
                        placeholder="enter email here" />
                </label>
                {/* <button onClick={handleSubmit}>
                    Submit
                </button> */}
                
            </form>
            <div>{JSON.stringify(person, null, 2)}</div>
        </div>
    );
}