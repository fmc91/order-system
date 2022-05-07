import React, { useState, useContext } from 'react';
import ProductsContext from './contexts/products-context';
import ProductList from './components/ProductList';
import EditProductModal from './components/EditProductModal';
import { FormContextProvider } from './components/forms/form-context';

export default function App() {
    
    const productsContext = useContext(ProductsContext);

    const [showEditModal, setShowEditModal] = useState(false);
    const [idOfProductToEdit, setIdOfProductToEdit] = useState(null);

    function handleEditButtonClick(id) {
        setIdOfProductToEdit(id);
        setShowEditModal(true);
    }

    function handleDeleteButtonClick(id) {
        productsContext.removeProduct(id);
    }

    function handleEditProduct(product) {
        console.log(product);
    }

    function handleDismissModal() {
        setShowEditModal(false);
        setIdOfProductToEdit(null);
    }

    var editProductModal =
        <FormContextProvider onSubmit={handleEditProduct}>
            <EditProductModal
                productId={idOfProductToEdit}
                onDismiss={handleDismissModal}/>
        </FormContextProvider>;
    
    return (
        <React.Fragment>
            <ProductList
                onEditButtonClick={handleEditButtonClick}
                onDeleteButtonClick={handleDeleteButtonClick}/>
            {showEditModal && editProductModal}
        </React.Fragment>
    );
}
