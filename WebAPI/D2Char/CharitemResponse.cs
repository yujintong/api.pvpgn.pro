﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CharacterEditor;


namespace WebAPI.D2Char
{
    /// <summary>
    /// Response for Item
    /// </summary>
    public class CharItemResponse : CharacterResponse
    {
        public CharItemResponse() { }

        public CharItemResponse(Item item)
        {
            var originalData = item.GetItemBytes();
            // set default item position, this way item bytes (and hash) will equal to the same items which contain different positions
            Data = Helper.DefaultItemPosition(originalData).GetItemBytes();
            Hash = Helper.MD5(Data);


            // FIXME: ORDER IS IMPORTANT AND MUST BE THE SAME AS IN ItemRepository! (otherwise item hashes are different)
            foreach (var socket in item.Sockets)
                Sockets.Add(new CharItemResponse(socket));

            foreach (var prop in item.Properties)
                Properties.Add(new PropertyInfoResponse(prop));

            foreach (var prop in item.PropertiesRuneword)
                PropertiesRuneword.Add(new PropertyInfoResponse(prop));

            foreach (var prop in item.PropertiesSet)
                PropertiesSet.Add(new PropertyInfoResponse(prop));

            IsEquipped = item.IsEquipped;
            IsInSocket = item.IsInSocket;
            IsIdentified = item.IsIdentified;
            IsSwitchIn = item.IsSwitchIn;
            IsSwitchOut = item.IsSwitchOut;
            IsBroken = item.IsBroken;
            IsSocketed = item.IsSocketed;
            IsPotion = item.IsPotion;
            IsStoreItem = item.IsStoreItem;
            IsNotInSocket = item.IsNotInSocket;
            IsEar = item.IsEar;
            IsStarterItem = item.IsStarterItem;
            IsSimpleItem = item.IsSimpleItem;
            IsEthereal = item.IsEthereal;
            IsPersonalized = item.IsPersonalized;
            IsGamble = item.IsGamble;
            IsRuneword = item.IsRuneword;
            Location = item.Location;
            PositionOnBody = item.PositionOnBody;
            PositionX = item.PositionX;
            PositionY = item.PositionY;
            StorageId = item.StorageId;
            ItemCode = item.ItemCode;
            GoldAmountSmall = item.GoldAmountSmall;
            GoldAmountLarge = item.GoldAmountLarge;
            SocketsFilled = item.SocketsFilled;
            Id = item.Id;
            Level = item.Level;
            Quality = item.Quality;
            HasGraphic = item.HasGraphic;
            Graphic = item.Graphic;
            UniqueSetId = item.UniqueSetId;
            Defense = item.Defense;
            MaxDurability = item.MaxDurability;
            Durability = item.Durability;
            IsIndestructable = item.IsIndestructable;
            SocketCount = item.SocketCount;
            Quantity = item.Quantity;
            RandomFlag = item.RandomFlag;
            UnknownGoldFlag = item.UnknownGoldFlag;
            ClassFlag = item.ClassFlag;
            ClassInfo = item.ClassInfo;
            InferiorQualityType = item.InferiorQualityType;
            SuperiorQualityType = item.SuperiorQualityType;
            CharmData = item.CharmData;
            SpellId = item.SpellId;
            MonsterId = item.MonsterId;
            EarClass = item.EarClass;
            EarLevel = item.EarLevel;
            EarName = item.EarName;
            PersonalizedName = item.PersonalizedName;
            RunewordId = item.RunewordId;
            PrefixNameId = item.PrefixNameId;
            SuffixNameId = item.SuffixNameId;
            PrefixFlag0 = item.PrefixFlag0;
            PrefixFlag1 = item.PrefixFlag1;
            PrefixFlag2 = item.PrefixFlag2;
            SuffixFlag0 = item.SuffixFlag0;
            SuffixFlag1 = item.SuffixFlag1;
            SuffixFlag2 = item.SuffixFlag2;
            MagicPrefix = item.MagicPrefix;
            MagicSuffix = item.MagicSuffix;
            Prefix0 = item.Prefix0;
            Prefix1 = item.Prefix1;
            Prefix2 = item.Prefix2;
            Suffix0 = item.Suffix0;
            Suffix1 = item.Suffix1;
            Suffix2 = item.Suffix2;

            DisplayData = new ItemDisplayResponse(item);
        }



        /// <summary>
        /// Return item object
        /// </summary>
        public Item GetItem(Item item)
        {
            item.Sockets.Clear();
            foreach (var socket in Sockets)
                item.Sockets.Add(socket.GetItem(Item.NewItem(socket.Data)));

            item.Properties.Clear();
            foreach (var prop in Properties)
                item.Properties.Add(prop.GetProperty());

            item.PropertiesRuneword.Clear();
            foreach (var prop in PropertiesRuneword)
                item.PropertiesRuneword.Add(prop.GetProperty());

            item.PropertiesSet.Clear();
            foreach (var prop in PropertiesSet)
                item.PropertiesSet.Add(prop.GetProperty());

            item.IsEquipped = IsEquipped;
            item.IsInSocket = IsInSocket;
            item.IsIdentified = IsIdentified;
            item.IsSwitchIn = IsSwitchIn;
            item.IsSwitchOut = IsSwitchOut;
            item.IsBroken = IsBroken;
            item.IsSocketed = IsSocketed;
            item.IsPotion = IsPotion;
            item.IsStoreItem = IsStoreItem;
            item.IsNotInSocket = IsNotInSocket;
            item.IsEar = IsEar;
            item.IsStarterItem = IsStarterItem;
            item.IsSimpleItem = IsSimpleItem;
            item.IsEthereal = IsEthereal;
            item.IsPersonalized = IsPersonalized;
            item.IsGamble = IsGamble;
            item.IsRuneword = IsRuneword;
            item.Location = Location;
            item.PositionOnBody = PositionOnBody;
            item.PositionX = PositionX;
            item.PositionY = PositionY;
            item.StorageId = StorageId;
            item.ItemCode = ItemCode;
            item.GoldAmountSmall = GoldAmountSmall;
            item.GoldAmountLarge = GoldAmountLarge;
            item.SocketsFilled = SocketsFilled;
            item.Id = Id;
            item.Level = Level;
            item.Quality = Quality;
            item.HasGraphic = HasGraphic;
            item.Graphic = Graphic;
            item.UniqueSetId = UniqueSetId;
            item.Defense = Defense;
            item.MaxDurability = MaxDurability;
            item.Durability = Durability;
            item.IsIndestructable = IsIndestructable;
            item.SocketCount = SocketCount;
            item.Quantity = Quantity;
            item.RandomFlag = RandomFlag;
            item.UnknownGoldFlag = UnknownGoldFlag;
            item.ClassFlag = ClassFlag;
            item.ClassInfo = ClassInfo;
            item.InferiorQualityType = InferiorQualityType;
            item.SuperiorQualityType = SuperiorQualityType;
            item.CharmData = CharmData;
            item.SpellId = SpellId;
            item.MonsterId = MonsterId;
            item.EarClass = EarClass;
            item.EarLevel = EarLevel;
            //item.EarName = EarName; // readonly
            //item.PersonalizedName = PersonalizedName; // readonly
            item.RunewordId = RunewordId;
            item.PrefixNameId = PrefixNameId;
            item.SuffixNameId = SuffixNameId;
            item.PrefixFlag0 = PrefixFlag0;
            item.PrefixFlag1 = PrefixFlag1;
            item.PrefixFlag2 = PrefixFlag2;
            item.SuffixFlag0 = SuffixFlag0;
            item.SuffixFlag1 = SuffixFlag1;
            item.SuffixFlag2 = SuffixFlag2;
            item.MagicPrefix = MagicPrefix;
            item.MagicSuffix = MagicSuffix;
            item.Prefix0 = Prefix0;
            item.Prefix1 = Prefix1;
            item.Prefix2 = Prefix2;
            item.Suffix0 = Suffix0;
            item.Suffix1 = Suffix1;
            item.Suffix2 = Suffix2;

            return item;
        }


        public new String FileType = "charitem";
        public String Hash;
        public byte[] Data;


        public List<CharItemResponse> Sockets = new List<CharItemResponse>();
        public List<PropertyInfoResponse> Properties = new List<PropertyInfoResponse>();
        public List<PropertyInfoResponse> PropertiesRuneword = new List<PropertyInfoResponse>();
        public List<PropertyInfoResponse> PropertiesSet = new List<PropertyInfoResponse>();


        public bool IsEquipped;
        public bool IsInSocket;
        public bool IsIdentified;
        public bool IsSwitchIn;
        public bool IsSwitchOut;
        public bool IsBroken;
        public bool IsSocketed;
        public bool IsPotion;
        public bool IsStoreItem;
        public bool IsNotInSocket;
        public bool IsEar;
        public bool IsStarterItem;
        public bool IsSimpleItem;
        public bool IsEthereal;
        public bool IsPersonalized;
        public bool IsGamble;
        public bool IsRuneword;
        public uint Location;
        public uint PositionOnBody;
        public uint PositionX;
        public uint PositionY;
        public uint StorageId;
        public string ItemCode;
        public uint GoldAmountSmall;
        public uint GoldAmountLarge;
        public uint SocketsFilled;
        public uint Id;
        public uint Level;
        public uint Quality;
        public bool HasGraphic;
        public uint Graphic;
        public uint UniqueSetId;
        public uint Defense;
        public uint MaxDurability;
        public uint Durability;
        public bool IsIndestructable;
        public uint SocketCount;
        public uint Quantity;
        public bool RandomFlag;
        public bool UnknownGoldFlag;
        public bool ClassFlag;
        public uint ClassInfo;
        public uint InferiorQualityType;
        public uint SuperiorQualityType;
        public uint CharmData;
        public uint SpellId;
        public uint MonsterId;
        public uint EarClass;
        public uint EarLevel;
        public string EarName;
        public string PersonalizedName;
        public uint RunewordId;
        public uint PrefixNameId;
        public uint SuffixNameId;
        public bool PrefixFlag0;
        public bool PrefixFlag1;
        public bool PrefixFlag2;
        public bool SuffixFlag0;
        public bool SuffixFlag1;
        public bool SuffixFlag2;
        public uint MagicPrefix;
        public uint MagicSuffix;
        public uint Prefix0;
        public uint Prefix1;
        public uint Prefix2;
        public uint Suffix0;
        public uint Suffix1;
        public uint Suffix2;


        public ItemDisplayResponse DisplayData;

        /// <summary>
        /// Properties to display in Item popup window on the page
        /// </summary>
        public class ItemDisplayResponse
        {
            public ItemDisplayResponse() { }

            public ItemDisplayResponse(Item item)
            {
                Title = ItemDefs.GetItemDescription(item.ItemCode);
                UniqueSetName = ItemDefs.GetUniqueSetName(item.ItemCode);
                ImageFile = ItemDefs.GetItemImageFile(item);
            }

            public string Title;
            public string UniqueSetName;
            public string ImageFile;
            public string ImagePath => $"images/d2gfx/{ImageFile}.gif";

            /// <summary>
            /// TODO: HTML representation of the item description
            /// </summary>
            //public string Html;

        }

        public class PropertyInfoResponse
        {
            public PropertyInfoResponse() { }

            public PropertyInfoResponse(Item.PropertyInfo prop)
            {
                ID = prop.ID;
                Value = prop.Value;
                ParamValue = prop.ParamValue;
                IsAdditionalProperty = prop.IsAdditionalProperty;

				// UNDONE:
                //Description = ItemDefs.GetPropDescription(prop);
            }

            /// <summary>
            /// Return property object
            /// </summary>
            /// <returns></returns>
            public Item.PropertyInfo GetProperty()
            {
                var prop = new Item.PropertyInfo
                {
                    ID = ID,
                    Value = Value,
                    ParamValue = ParamValue,
                    IsAdditionalProperty = IsAdditionalProperty,
                };

                return prop;
            }

            public int ID;
            public int Value;
            public int ParamValue;
            public bool IsAdditionalProperty;

            public string Description; // readonly
        }
    }


}