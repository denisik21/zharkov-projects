package repositories

import (
	"DeliveryClub/internal/models"
	"context"

	"testing"
)

func TestStoreRepository(t *testing.T) {
	ctx := context.Background()
	repo := NewStoreRepository()

	stores, err := repo.Get(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(stores) != 2 {
		t.Errorf("expected 2 stores but got %d", len(stores))
	}

	newStores := []models.Store{
		{ID: 3, Location: "Store C"},
	}
	err = repo.AddRange(ctx, newStores)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}

	stores, err = repo.Get(ctx)
	if err != nil {
		t.Errorf("expected no error but got %v", err)
	}
	if len(stores) != 3 {
		t.Errorf("expected 3 stores but got %d", len(stores))
	}
}
