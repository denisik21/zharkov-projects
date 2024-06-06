package services

import (
	"DeliveryClub/internal/models"
	"DeliveryClub/internal/repositories"
	"context"

	"testing"
)

func TestWarehouseService(t *testing.T) {
	ctx := context.Background()
	repo := repositories.NewWarehouseRepository()
	service := NewWarehouseService(repo)

	warehouses, err := service.GetWarehouses(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(warehouses) != 2 {
		t.Errorf("expected 2 warehouses but got %d", len(warehouses))
	}

	newWarehouses := []models.Warehouse{
		{ID: 3, Location: "Warehouse C", Email: "c@example.com"},
	}
	err = service.RegisterOrUpdateWarehouses(ctx, newWarehouses)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}

	warehouses, err = service.GetWarehouses(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(warehouses) != 3 {
		t.Errorf("expected 3 warehouses but got %d", len(warehouses))
	}
}
