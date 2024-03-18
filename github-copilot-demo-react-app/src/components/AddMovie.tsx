import React, { useState } from "react";

interface Movie {
  title: string;
  director: string;
  year: number;
}

const AddMovie: React.FC = () => {
  const [movie, setMovie] = useState<Movie>({
    title: "",
    director: "",
    year: 0,
  });

  const handleInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = event.target;
    setMovie((prevMovie) => ({
      ...prevMovie,
      [name]: value,
    }));
  };

  const handleAddMovie = () => {
    // Add your logic here to save the movie to the JSON file
    console.log("Movie:", movie);
  };

  const deleteMovie = () => {
    const deleteMovie = async () => {
      try {
        // Make a DELETE request to the API to delete the movie
        await fetch(`/api/movies/${movie.id}`, {
          method: "DELETE",
        });

        // Update the movie state or perform any other necessary actions
        console.log("Movie deleted successfully");
      } catch (error) {
        console.error("Error deleting movie:", error);
      }
    };
  };

  return (
    <div>
      <h2>Add Movie</h2>
      <form>
        <div>
          <label>Title:</label>
          <input
            type="text"
            name="title"
            value={movie.title}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Director:</label>
          <input
            type="text"
            name="director"
            value={movie.director}
            onChange={handleInputChange}
          />
        </div>
        <div>
          <label>Year:</label>
          <input
            type="number"
            name="year"
            value={movie.year}
            onChange={handleInputChange}
          />
        </div>
        <button type="button" onClick={handleAddMovie}>
          Add Movie
        </button>

        <button type="button" onClick={deleteMovie}>
          Delete Movie
        </button>
      </form>
    </div>
  );
};

export default AddMovie;
