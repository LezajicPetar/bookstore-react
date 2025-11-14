import React from "react";
import { useForm } from "react-hook-form";
import "../styles/reviewModal.scss";
import { createReview } from "../service/reviewService";

const ReviewModal = ({ book, onClose }) => {

    const { register, handleSubmit, formState: { errors } } = useForm();

    const closeReviewModal = () => {
        onClose(null);
    }
    const onSubmitReview = async (data) => {

        const review = {
            userId: 1,
            bookId: book.id,
            rating: data.rating,
            comment: data.comment,
        };

        try {
            await createReview(book.id, review);
            alert("Your review has taken root. Thanks for growing our Leaf community!");
            onClose(null);
        }
        catch (error) {
            alert("The branch snapped — an error occurred. Try again.");
        }
    }

    return (
        <div className="modal-overlay">
            <div className="modal">
                <h2>Review: {book.title}</h2>

                <form className="review-form" onSubmit={handleSubmit(onSubmitReview)}>
                    <div className="form-field">
                        <label htmlFor="rating">Rating (1–5)</label>
                        <input
                            id="rating"
                            type="number"
                            {...register("rating", {
                                required: "Rating is required",
                                min: { value: 1, message: "Min rating is 1" },
                                max: { value: 5, message: "Max rating is 5" },
                            })}
                        />
                        {errors.rating && (
                            <span className="error-text">{errors.rating.message}</span>
                        )}
                    </div>

                    <div className="form-field">
                        <label htmlFor="comment">Comment:</label>
                        <textarea
                            id="comment"
                            rows={4}
                            {...register("comment", {
                                required: "Comment is required",
                                max: { value: 250, message: "Max comment length is 250 characters" }
                            })}
                        />
                        {errors.comment && (
                            <span className="error-text">{errors.comment.message}</span>
                        )}
                    </div>

                    <div className="modal-actions">
                        <button type="button" className="btn btn-secondary" onClick={closeReviewModal}>
                            Cancel
                        </button>

                        <button type="submit" className="btn btn-primary">
                            Submit review
                        </button>
                    </div>
                </form>
            </div>
        </div>)
}

export default ReviewModal;