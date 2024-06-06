package repositories

import (
	"DeliveryClub/internal/models"
	"context"

	"testing"
)

func TestWarehouseRepository(t *testing.T) {
	ctx := context.Background()
	repo := NewWarehouseRepository()

	warehouses, err := repo.Get(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(warehouses) != 2 {
		t.Errorf("expected 2 warehouses but got %d", len(warehouses))
	}

	newWarehouses := []models.Warehouse{
		{ID: 3, Location: "Warehouse C", Email: "c@example.com"},
	}
	err = repo.AddRange(ctx, newWarehouses)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}

	warehouses, err = repo.Get(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(warehouses) != 3 {
		t.Errorf("expected 3 warehouses but got %d", len(warehouses))
	}
}
