﻿using HearthstoneNHibernate.CardClasses;
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
    public class NHibernateMapper
    {
        private readonly ModelMapper _modelMapper;

        public NHibernateMapper()
        {
            _modelMapper = new ModelMapper();
        }

        public HbmMapping Map()
        {
            MapRarity();
            MapPlayerClass();
            MapPlayer();

            MapCard();

            MapAbility();
            MapCardSet();


            MapWeapon();
            MapSpell();
           

            
            
            return _modelMapper.CompileMappingForAllExplicitlyAddedEntities();
        }

        private void MapCard()
        {
            _modelMapper.Class<Card>(e =>
            {
                e.Id(p => p.CardId, p => p.Generator(Generators.GuidComb));

                e.ManyToOne(p => p.Rarity, mapper =>
                {
                    mapper.Column("RarityId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });

                e.Property(p => p.CardName, p => p.Unique(true));
                e.Property(p => p.CardText);
                e.Property(p => p.Cost);
                
                e.Set(x => x.Abilities, collectionMapping =>
                {
                    collectionMapping.Table("Abilities");
                    collectionMapping.Cascade(Cascade.None);
                    collectionMapping.Key(keyMap => keyMap.Column("AbilityId"));
                }, map => map.ManyToMany(p => p.Column("CardId")));

                e.ManyToOne(p => p.CardSet, mapper =>
                {
                    mapper.Column("CardSetId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });







                e.ManyToOne(p => p.PlayerClass, mapper =>
                {
                    mapper.Column("PlayerClassId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });
            });
        }

        private void MapSpell()
        {
            _modelMapper.Class<Spell>(e =>
            {
                e.Id(p => p.SpellId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.Damage);
                e.Property(p => p.Heal);
                e.Property(p => p.ToAll);
                e.ManyToOne(p => p.Card, mapper =>
                {
                    mapper.Column("CardId");
                    mapper.NotNullable(true);
                    mapper.Cascade(Cascade.All);
                });
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


        
        private void MapCardSet()
        {
            _modelMapper.Class<CardSet>(e =>
            {
                e.Id(p => p.CardSetId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.CardSetName);
                //e.Set(p => p.Cards, p =>
                //{
                //    p.Inverse(true);
                //    p.Cascade(Cascade.All);
                //    p.Key(k => k.Column(col => col.Name("CardId")));
                //}, p => p.OneToMany());
            });
        }
        private void MapPlayerClass()
        {
            _modelMapper.Class<PlayerClass>(e =>
            {
                e.Id(p => p.PlayerClassIdX, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.ClassName);
                //e.Set(p => p.Cards, p =>
                //{
                //    p.Inverse(true);
                //    p.Cascade(Cascade.All);
                //    p.Key(k => k.Column(col => col.Name("CardId")));
                //}, p => p.OneToMany());
            });
        }
        private void MapRarity()
        {
            _modelMapper.Class<Rarity>(e =>
            {
                e.Id(p => p.RarityId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.RarityName);
                //e.Set(p => p.Cards, p =>
                //{
                //    p.Inverse(true);
                //    p.Cascade(Cascade.All);
                //    p.Key(k => k.Column(col => col.Name("CardId")));
                //}, p => p.OneToMany());
            });
        }

        private void MapAbility()
        {
            _modelMapper.Class<Ability>(e =>
            {
                e.Id(p => p.AbilityId, p => p.Generator(Generators.GuidComb));
                e.Property(p => p.AbilityName);
                //e.Set(x => x.Cards, collectionMapping =>
                //{
                //    collectionMapping.Inverse(true);
                //    collectionMapping.Table("Abilities");
                //    collectionMapping.Cascade(Cascade.None);
                //    collectionMapping.Key(keymap => keymap.Column("CardId"));
                //}, map => map.ManyToMany(p => p.Column("AbilityId")));
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
