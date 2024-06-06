package repositories

import (
	"DeliveryClub/internal/models"
	"context"
)

type WarehouseRepository struct {
	warehouses []models.Warehouse
}

func NewWarehouseRepository() *WarehouseRepository {
	return &WarehouseRepository{
		warehouses: []models.Warehouse{
			{ID: 1, Location: "Warehouse A", Email: "a@example.com"},
			{ID: 2, Location: "Warehouse B", Email: "b@example.com"},
		},
	}
}

func (wr *WarehouseRepository) Get(ctx context.Context) ([]models.Warehouse, error) {
	return wr.warehouses, nil
}

func (wr *WarehouseRepository) AddRange(ctx context.Context, items []models.Warehouse) error {
	wr.warehouses = append(wr.warehouses, items...)
	return nil
}

func (wr *WarehouseRepository) UpdateRange(ctx context.Context, items []models.Warehouse) error {
	for _, newItem := range items {
		for i, oldItem := range wr.warehouses {
			if oldItem.ID == newItem.ID {
				wr.warehouses[i] = newItem
				break
			}
		}
	}
	return nil
}
