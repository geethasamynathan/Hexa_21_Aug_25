import { useEffect, useState, useRef } from "react";
import { Link } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import {
  fetchProducts,
  removeProduct,
  searchProductList,
} from "../features/product/productSlice";
// import {
//   getAllProducts,
//   deleteProduct,
//   searchProducts,
// } from "../Services/ProductService";

export default function ProductList({ roles }) {
  const dispatch = useDispatch();
  const { items: products, loading } = useSelector((state) => state.products);
  //const [products, setProducts] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(15);
  const [searchTerm, setSearchTerm] = useState("");
  const debounceRef = useRef(null);
  useEffect(() => {
    dispatch(fetchProducts());
    //loadProducts();
  }, []);

  const handleDelete = async (id) => {
    // await dispatch(removeProduct(id));
    //   const response = await dispatch(fetchProducts());
    const token = localStorage.getItem("token");
    const roles = JSON.parse(localStorage.getItem("roles") || "[]");

    if (!token) {
      // 🚀 Not logged in → go to login
      window.location.href = "/login";
      return;
    }

    if (!roles.includes("User")) {
      alert("❌ You don't have permission to delete products");
      return;
    }

    await dispatch(removeProduct(id));
    await dispatch(fetchProducts());
    //setProducts(response);
  };

  const handleSearchChange = (e) => {
    const value = e.target.value;
    setSearchTerm(value);
    if (debounceRef.current) clearTimeout(debounceRef.current);

    if (value.length === 0) {
      dispatch(fetchProducts());
      //loadProducts();
      return;
    }
    if (value.length >= 3) {
      debounceRef.current = setTimeout(() => {
        dispatch(searchProductList(value));
        // loadProducts(value);
      }, 3000);
    }
  };

  //handle Enter Key
  const handleEnterSearchKeyDown = (e) => {
    if (e.key == "Enter" && searchTerm.length >= 3) {
      if (debounceRef.current) clearTimeout(debounceRef.current);
      loadProducts(searchTerm);
    }
  };

  // Pagination logic
  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = products.slice(indexOfFirstItem, indexOfLastItem);
  const totalPages = Math.ceil(products.length / itemsPerPage);

  const paginate = (pageNumber) => setCurrentPage(pageNumber);

  const renderPageNumbers = () => {
    const pages = [];
    const maxVisible = 5; // how many pages to show around current

    // Always show first page
    if (currentPage > 2) {
      pages.push(1);
      if (currentPage > 3) {
        pages.push("...");
      }
    }

    // Show window around current page
    let start = Math.max(2, currentPage - 2);
    let end = Math.min(totalPages - 1, currentPage + 2);

    for (let i = start; i <= end; i++) {
      pages.push(i);
    }

    // Always show last page
    if (currentPage < totalPages - 1) {
      if (currentPage < totalPages - 2) {
        pages.push("...");
      }
      pages.push(totalPages);
    }

    return pages;
  };

  return (
    <div className="container mt-5">
      <h2 className="mb-3 text-success">Product List</h2>
      <div className="input-group-mb-3">
        <span className="input-group-text">
          <i className="bi bi-search"></i>
        </span>
        <input
          typeof="text"
          className="form-control"
          placeholder="Search Product name ..."
          value={searchTerm}
          onChange={handleSearchChange}
          onKeyDown={handleEnterSearchKeyDown}
        />
      </div>
      {roles.includes("Admin") && (
        <Link to="/add" className="btn btn-success mb-3">
          ➕ Add Product
        </Link>
      )}

      <table className="table table-striped table-bordered shadow">
        <thead className="table-dark">
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Brand</th>
            <th>Category</th>
            <th>Model Year</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {currentItems.length > 0 ? (
            currentItems.map((p) => (
              <tr key={p.product_id}>
                <td>{p.product_id}</td>
                <td>{p.product_name}</td>
                <td>{p.brand_id}</td>
                <td>{p.category_id}</td>
                <td>{p.model_year}</td>
                <td>{p.list_price}</td>
                <td>
                  {roles.includes("Admin") && (
                    <Link
                      to={`/edit/${p.product_id}`}
                      className="btn btn-sm btn-primary me-2"
                    >
                      ✏️ Edit
                    </Link>
                  )}
                  {roles.includes("User") && (
                    <button
                      onClick={() => handleDelete(p.product_id)}
                      className="btn btn-sm btn-danger"
                    >
                      🚮 Delete
                    </button>
                  )}
                </td>
              </tr>
            ))
          ) : (
            <tr>
              <td colSpan="7" className="text-center text-muted">
                No products available
              </td>
            </tr>
          )}
        </tbody>
      </table>

      {/* Pagination */}
      {totalPages > 1 && (
        <nav>
          <ul className="pagination justify-content-center">
            {/* Prev button */}
            <li className={`page-item ${currentPage === 1 ? "disabled" : ""}`}>
              <button
                onClick={() => paginate(currentPage - 1)}
                className="page-link"
                disabled={currentPage === 1}
              >
                Prev
              </button>
            </li>

            {/* Page numbers */}
            {renderPageNumbers().map((num, idx) => (
              <li
                key={idx}
                className={`page-item ${currentPage === num ? "active" : ""} ${
                  num === "..." ? "disabled" : ""
                }`}
              >
                <button
                  className="page-link"
                  onClick={() => num !== "..." && paginate(num)}
                >
                  {num}
                </button>
              </li>
            ))}

            {/* Next button */}
            <li
              className={`page-item ${
                currentPage === totalPages ? "disabled" : ""
              }`}
            >
              <button
                className="page-link"
                onClick={() => paginate(currentPage + 1)}
                disabled={currentPage === totalPages}
              >
                Next
              </button>
            </li>
          </ul>
        </nav>
      )}
    </div>
  );
}
