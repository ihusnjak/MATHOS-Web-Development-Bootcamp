import { useState } from "react";
export default function SearchParams() {
    const [location, setLocation] = useState("Osijek, Croatia");
    return (
        <div className="search-params">
            <form>
                <label htmlFor="location">
                    Location
                    <input id="location"
                        onChange={(e) => setLocation(e.target.value)}
                        value={location}
                        placeholder="Location" />
                </label>
                <button>Submit</button>
            </form>
        </div>
    );
}