import { getAllPublishers } from '../service/publishersService';
import React, { useEffect, useState } from 'react';

const Publishers = () => {
    const [publishers, setPublishers] = useState([]);

    useEffect(() => {
        const fetchPublishers = async () => {
            try {
                const data = await getAllPublishers();
                setPublishers(data);
            }
            catch (error) {
                console.error("Error fetching publishers:", error);
                alert("This leaf is missing from the branch. \nWe couldn’t fetch the publishers right now.");
            }
        }
        fetchPublishers();
    }, [])

    return (
        <div>
            <table>
                <thead>
                    <tr>
                        <td>Name</td>
                        <td>Adress</td>
                        <td>Website</td>
                    </tr>
                </thead>
                <tbody>
                    {publishers.map((publisher) => (
                        <tr key={publisher.id}>
                            <td>{publisher.name}</td>
                            <td>{publisher.address}</td>
                            <td>{publisher.website}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default Publishers;