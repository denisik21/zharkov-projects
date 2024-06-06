package repositories

import (
	"DeliveryClub/internal/models"
	"context"
)

type StoreRepository struct {
	stores []models.Store
}

func NewStoreRepository() *StoreRepository {
	return &StoreRepository{
		stores: []models.Store{
			{ID: 1, Location: "Store A"},
			{ID: 2, Location: "Store B"},
		},
	}
}

func (sr *StoreRepository) Get(ctx context.Context) ([]models.Store, error) {
	return sr.stores, nil
}

func (sr *StoreRepository) AddRange(ctx context.Context, items []models.Store) error {
	sr.stores = append(sr.stores, items...)
	return nil
}

func (sr *StoreRepository) UpdateRange(ctx context.Context, items []models.Store) error {
	for _, newItem := range items {
		for i, oldItem := range sr.stores {
			if oldItem.ID == newItem.ID {
				sr.stores[i] = newItem
				break
			}
		}
	}
	return nil
}
