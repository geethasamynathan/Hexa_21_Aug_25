import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { getAllProducts, deleteProduct } from "../Services/ProductService";

export default function ProductList() {
  const [products, setProducts] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [itemsPerPage] = useState(5);
  useEffect(() => {
    loadProducts();
  }, []);

  const loadProducts = async () => {
    const response = await getAllProducts();
    console.log(response);
    setProducts(response);
  };

  const handleDelete = async (id) => {
    await deleteProduct(id);
    loadProducts();
  };
  const indexOfLastItem = currentPage * itemsPerPage;
  const indexOfFirstItem = indexOfLastItem - itemsPerPage;
  const currentItems = products.slice(indexOfFirstItem, indexOfLastItem);
  const totalPages = Math.ceil(products.length / itemsPerPage);

  const paginate = (pageNumber) => setCurrentPage(pageNumber);

  const renderPageNumbers = () => {
    let pages = [];

    if (currentPage > 3) {
      pages.push(1, 2, "...");
    } else {
      for (let i = 1; i <= Math.min(3, totalPages); i++) {
        if (i > 2 && i < totalPages - 1) {
          pages.push(i);
        }
      }
      for (let i = currentPage - 2; i <= currentPage + 2; i++) {
        if (i > 2 && i < totalPages - 1) pages.push(i);
      }
    }

    if (currentPage < totalPages - 2) {
      pages.push("...", totalPages - 1, totalPages);
    } else {
      for (let i = totalPages - 2; i <= totalPages; i++) {
        if (i > 0) {
          pages.push(i);
        }
      }
    }
    return [...new Set(pages)];
  };
  return (
    <div className="container mt-5">
      <h2 className="mb-3 text-success"> Product Lsit</h2>
      <Link to="/add" className=" btn btn-success mb-3">
        ➕ Add Product
      </Link>
      <table className="table table-stripped table-bordered shadow">
        <thead className="table-dark">
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Brand</th>
            <th>Category</th>
            <th> Model Year</th>
            <th>Price</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {currentItems.map((p) => (
            <tr key={p.product_id}>
              <td>{p.product_id}</td>
              <td>{p.product_name}</td>
              <td>{p.brand_id}</td>
              <td>{p.category_id}</td>
              <td>{p.model_year}</td>
              <td>{p.list_price}</td>
              <td>
                <Link to={`/edit/${p.product_id}`}> ✏️ Edit</Link>
                <button onClick={() => handleDelete(p.product_id)}>
                  🚮 Delete
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>

      <nav>
        <ul className="pagination justify-content-center">
          <li className="{`page-item ${currentPage === 1 ? 'disabled':''}`}">
            <button
              onClick={() => paginate(currentPage - 1)}
              className="page-link"
              disabled={currentPage === 1}
            >
              Prev
            </button>
          </li>

          {renderPageNumbers().map((num, idx) => (
            <li
              key={idx}
              className="{`page-item ${currentPage === num ? 'active':''} ${num==='...? 'disabled':''}`}"
            >
              <button
                className="page-link"
                onClick={() => num !== "..." && paginate(num)}
              >
                {num}
              </button>
            </li>
          ))}
          <li className="{`page-item ${currentPage === totalpages? 'disabled':''}`}">
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
    </div>
  );
}
