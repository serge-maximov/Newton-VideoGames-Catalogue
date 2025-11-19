export interface VideoGame {
  id: number;
  title: string;
  genre: string;
  releaseYear: number;
  platform: string;
  description: string;
  rating?: string;
  price: number;
}