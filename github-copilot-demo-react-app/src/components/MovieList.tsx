import React from "react";

interface Movie {
  title: string;
  genre: string;
  year: number;
}

interface MovieListProps {
  movies: Movie[];
}

const MovieList: React.FC<MovieListProps> = ({ movies }) => {
  return (
    <div>
      <h2>Movies</h2>
      <ul>
        {movies.map((movie, index) => (
          <li key={index}>
            <strong>{movie.title}</strong> - {movie.genre} ({movie.year})
          </li>
        ))}
      </ul>
    </div>
  );
};

export default MovieList;
