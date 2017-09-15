using HearthstoneNHibernate.CardClasses;
using HearthstoneNHibernate.Domain;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneNHibernate.Mapping
{
    class NHibernateMapper
    {
        private readonly ModelMapper _modelMapper;

        public NHibernateMapper()
        {
            _modelMapper = new ModelMapper();
        }

        public HbmMapping Map()
        {
            MapPlayer();
            MapAbility();
            MapPlayerClass();
            MapCard();
            MapCardSet();
            MapRarity();
            MapWeapon();

            return _modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        private void MapCard()
        {
            _modelMapper.Class<Card>(e =>
            {
                e.Id(p => p.CardId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.CardName);
                e.Property(p => p.CardText);
                e.Property(p => p.Cost);
                e.ManyToOne(p => p.PlayerClass, mapper =>
                {
                    mapper.Column("PlayerClassId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });
                e.ManyToOne(p => p.CardSet, mapper =>
                {
                    mapper.Column("CardSetId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });
                e.ManyToOne(p => p.Rarity, mapper =>
                {
                    mapper.Column("RarityId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });

                e.Set(x => x.Abilities, collectionMapping => 
                {
                    collectionMapping.Table("Abilities");
                    collectionMapping.Cascade(Cascade.None);
                    collectionMapping.Key(keyMap => keyMap.Column("AbilityId"));
                }, map => map.ManyToMany(p => p.Column("CardId")));
            });
        }

        private void MapWeapon()
        {
            _modelMapper.Class<Weapon>(e =>
            {
                e.Id(p => p.WeaponId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.Attack);
                e.Property(p => p.Durability);
                e.ManyToOne(p => p.Card, mapper =>
                {
                    mapper.Column("CardId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });
            });
        }

        private void MapPlayerClass()
        {
            _modelMapper.Class<PlayerClass>(e =>
            {
                e.Id(p => p.PlayerClassId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.ClassName);
            });
        }
        
        private void MapCardSet()
        {
            _modelMapper.Class<CardSet>(e =>
            {
                e.Id(p => p.CardSetId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.CardSetName);
            });
        }

        private void MapRarity()
        {
            _modelMapper.Class<Rarity>(e =>
            {
                e.Id(p => p.RarityId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.RarityName);
            });
        }

        private void MapAbility()
        {
            _modelMapper.Class<Ability>(e =>
            {
                e.Id(p => p.AbilityId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.AbilityName);
                e.Set(x => x.Cards, collectionMapping => 
                {
                    collectionMapping.Inverse(true);
                    collectionMapping.Table("Abilities");
                    collectionMapping.Cascade(Cascade.None);
                    collectionMapping.Key(keymap => keymap.Column("CardId"));
                }, map => map.ManyToMany(p => p.Column("AbilityId")));
            });
        }

        private void MapPlayer()
        {
            _modelMapper.Class<Player>(e => 
            {
                e.Id(p => p.Id, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.Age);
                e.Property(p => p.Name);
            });
        }
    }
}
