package services

import (
	"DeliveryClub/internal/models"
	"DeliveryClub/internal/repositories"
	"context"

	"testing"
)

func TestStoreService(t *testing.T) {
	ctx := context.Background()
	repo := repositories.NewStoreRepository()
	service := NewStoreService(repo)

	stores, err := service.GetStores(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(stores) != 2 {
		t.Errorf("expected 2 stores but got %d", len(stores))
	}

	newStores := []models.Store{
		{ID: 3, Location: "Store C"},
	}
	err = service.RegisterOrUpdateStores(ctx, newStores)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}

	stores, err = service.GetStores(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(stores) != 3 {
		t.Errorf("expected 3 stores but got %d", len(stores))
	}
}
