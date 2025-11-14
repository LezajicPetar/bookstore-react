import axios from "../config/AxioConfig.js";

export const createReview = async (bookId, review) => {
    const response = await axios.post(`reviews/${bookId}`, review);
    return response.data;
}