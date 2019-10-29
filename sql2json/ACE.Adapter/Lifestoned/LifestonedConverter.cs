using System;
using System.Collections.Generic;
using System.Linq;

using ACE.Database.Models.World;
using ACE.Entity.Enum.Properties;

using Newtonsoft.Json;

namespace ACE.Adapter.Lifestoned
{
    public static class LifestonedConverter
    {
         public static bool TryConvert(Weenie input, out global::Lifestoned.DataModel.Gdle.Weenie result, bool correctForEnumShift = false)
        {
            if (input.ClassId == 0)
            {
                result = null;
                return false;
            }

            try
            {
                result = new global::Lifestoned.DataModel.Gdle.Weenie();

                result.WeenieId = input.ClassId;

                result.WeenieTypeId = input.Type;

                if (input.WeeniePropertiesBook != null)
                {
                    result.Book = new global::Lifestoned.DataModel.Gdle.Book();
                    result.Book.MaxNumberPages = input.WeeniePropertiesBook.MaxNumPages;
                    result.Book.MaxCharactersPerPage = input.WeeniePropertiesBook.MaxNumCharsPerPage;

                    if (input.WeeniePropertiesBookPageData != null && input.WeeniePropertiesBookPageData.Count > 0)
                    {
                        result.Book.Pages = new List<global::Lifestoned.DataModel.Gdle.Page>();

                        //uint pageId = 0;

                        foreach (var value in input.WeeniePropertiesBookPageData.OrderBy(p => p.PageId))
                        {
                            result.Book.Pages.Add(new global::Lifestoned.DataModel.Gdle.Page
                            {
                                 //= pageId,

                                AuthorId = value.AuthorId,
                                AuthorName = value.AuthorName,
                                AuthorAccount = value.AuthorAccount,
                                IgnoreAuthor = value.IgnoreAuthor,
                                PageText = value.PageText,
                            });

                            //pageId++;
                        }
                    }
                }

                // LandblockInstance

                // PointsOfInterest

                // WeeniePropertiesAnimPart

                if (input.WeeniePropertiesAttribute != null && input.WeeniePropertiesAttribute.Count > 0)
                {
                    if (result.Attributes == null)
                        result.Attributes = new global::Lifestoned.DataModel.Gdle.AttributeSet();

                    result.Attributes.Strength = new global::Lifestoned.DataModel.Gdle.Attribute
                    {
                        Ranks = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Strength).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Strength).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Strength).CPSpent
                    };

                    result.Attributes.Endurance = new global::Lifestoned.DataModel.Gdle.Attribute
                    {
                        Ranks = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Endurance).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Endurance).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Endurance).CPSpent
                    };

                    result.Attributes.Quickness = new global::Lifestoned.DataModel.Gdle.Attribute
                    {
                        Ranks = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Quickness).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Quickness).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Quickness).CPSpent
                    };

                    result.Attributes.Coordination = new global::Lifestoned.DataModel.Gdle.Attribute
                    {
                        Ranks = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Coordination).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Coordination).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Coordination).CPSpent
                    };

                    result.Attributes.Focus = new global::Lifestoned.DataModel.Gdle.Attribute
                    {
                        Ranks = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Focus).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Focus).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Focus).CPSpent
                    };

                    result.Attributes.Self = new global::Lifestoned.DataModel.Gdle.Attribute
                    {
                        Ranks = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Self).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Self).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute.Self).CPSpent
                    };
                }

                if (input.WeeniePropertiesAttribute2nd != null && input.WeeniePropertiesAttribute2nd.Count > 0)
                {
                    if (result.Attributes == null)
                        result.Attributes = new global::Lifestoned.DataModel.Gdle.AttributeSet();

                    result.Attributes.Health = new global::Lifestoned.DataModel.Gdle.Vital
                    {
                        Ranks = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxHealth).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxHealth).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxHealth).CPSpent,
                        Current = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxHealth).CurrentLevel
                    };

                    result.Attributes.Stamina = new global::Lifestoned.DataModel.Gdle.Vital
                    {
                        Ranks = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxStamina).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxStamina).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxStamina).CPSpent,
                        Current = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxStamina).CurrentLevel
                    };

                    result.Attributes.Mana = new global::Lifestoned.DataModel.Gdle.Vital
                    {
                        Ranks = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxMana).InitLevel,
                        LevelFromCp = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxMana).LevelFromCP,
                        XpSpent = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxMana).CPSpent,
                        Current = input.WeeniePropertiesAttribute2nd.FirstOrDefault(a => a.Type == (ushort)PropertyAttribute2nd.MaxMana).CurrentLevel
                    };
                }

                if (input.WeeniePropertiesBodyPart != null && input.WeeniePropertiesBodyPart.Count > 0)
                {
                    result.Body = new global::Lifestoned.DataModel.Gdle.Body();
                    result.Body.BodyParts = new List<global::Lifestoned.DataModel.Gdle.BodyPartListing>();

                    foreach (var value in input.WeeniePropertiesBodyPart)
                    {
                        result.Body.BodyParts.Add(new global::Lifestoned.DataModel.Gdle.BodyPartListing
                        {
                            Key = value.Key,
                            BodyPartType = (global::Lifestoned.DataModel.Shared.BodyPartType)value.Key,
                            BodyPart = new global::Lifestoned.DataModel.Gdle.BodyPart
                            {
                                DType = value.DType,
                                DVal = value.DVal,
                                DVar = value.DVar,
                                ArmorValues = new global::Lifestoned.DataModel.Gdle.ArmorValues
                                {
                                    BaseArmor = value.BaseArmor,
                                    ArmorVsSlash = value.ArmorVsSlash,
                                    ArmorVsPierce = value.ArmorVsPierce,
                                    ArmorVsBludgeon = value.ArmorVsBludgeon,
                                    ArmorVsCold = value.ArmorVsCold,
                                    ArmorVsFire = value.ArmorVsFire,
                                    ArmorVsAcid = value.ArmorVsAcid,
                                    ArmorVsElectric = value.ArmorVsElectric,
                                    ArmorVsNether = value.ArmorVsNether
                                },
                                BH = value.BH,
                                SD = new global::Lifestoned.DataModel.Gdle.Zones
                                {
                                    HLF = value.HLF,
                                    MLF = value.MLF,
                                    LLF = value.LLF,

                                    HRF = value.HRF,
                                    MRF = value.MRF,
                                    LRF = value.LRF,

                                    HLB = value.HLB,
                                    MLB = value.MLB,
                                    LLB = value.LLB,

                                    HRB = value.HRB,
                                    MRB = value.MRB,
                                    LRB = value.LRB,
                                }
                            }
                        });
                    }
                }

                if (input.WeeniePropertiesBool != null && input.WeeniePropertiesBool.Count > 0)
                {
                    result.BoolStats = new List<global::Lifestoned.DataModel.Gdle.BoolStat>();

                    foreach (var value in input.WeeniePropertiesBool)
                    {
                        if (result.BoolStats.FirstOrDefault(x => x.Key == value.Type) == null)
                            result.BoolStats.Add(new global::Lifestoned.DataModel.Gdle.BoolStat { Key = value.Type, Value = Convert.ToInt32(value.Value) });
                    }
                }

                if (input.WeeniePropertiesCreateList != null && input.WeeniePropertiesCreateList.Count > 0)
                {
                    result.CreateList = new List<global::Lifestoned.DataModel.Gdle.CreateItem>();

                    foreach (var value in input.WeeniePropertiesCreateList)
                        result.CreateList.Add(new global::Lifestoned.DataModel.Gdle.CreateItem
                        {
                            WeenieClassId = value.WeenieClassId,
                            Palette = (uint)value.Palette,
                            Shade = value.Shade,
                            Destination = (uint)value.DestinationType,
                            StackSize = value.StackSize,
                            TryToBond = Convert.ToByte(value.TryToBond)
                        });
                }

                if (input.WeeniePropertiesDID != null && input.WeeniePropertiesDID.Count > 0)
                {
                    result.DidStats = new List<global::Lifestoned.DataModel.Gdle.DidStat>();

                    foreach (var value in input.WeeniePropertiesDID)
                    {
                        result.DidStats.Add(new global::Lifestoned.DataModel.Gdle.DidStat { Key = value.Type, Value = value.Value });
                    }
                }

                if (input.WeeniePropertiesEmote != null && input.WeeniePropertiesEmote.Count > 0)
                {
                    result.EmoteTable = new List<global::Lifestoned.DataModel.Gdle.EmoteCategoryListing>();

                    var eorder = 0;
                    foreach (var emote in input.WeeniePropertiesEmote)
                    {
                        var ec = new global::Lifestoned.DataModel.Gdle.EmoteCategoryListing
                        {
                            EmoteCategoryId = (int)emote.Category,
                            Emotes = new List<global::Lifestoned.DataModel.Gdle.Emote>(),
                        };

                        var em = new global::Lifestoned.DataModel.Gdle.Emote
                        {
                            SortOrder = eorder,
                            Category = emote.Category,
                            EmoteCategory = (global::Lifestoned.DataModel.Shared.EmoteCategory)emote.Category,
                            ClassId = emote.WeenieClassId,
                            MaxHealth = emote.MaxHealth,
                            MinHealth = emote.MinHealth,
                            Probability = emote.Probability,
                            Quest = emote.Quest,
                            Style = emote.Style,
                            SubStyle = emote.Substyle,
                            VendorType = (uint?)emote.VendorType,
                            Actions = new List<global::Lifestoned.DataModel.Gdle.EmoteAction>()
                        };

                        var aorder = 0;
                        foreach (var action in emote.WeeniePropertiesEmoteAction.OrderBy(e => e.Order))
                        {
                            var ea = new global::Lifestoned.DataModel.Gdle.EmoteAction
                            {
                                SortOrder = aorder,
                                Amount = (uint?)action.Amount,
                                Amount64 = (uint?)action.Amount64,
                                Delay = action.Delay,
                                EmoteActionType = action.Type,
                                Extent = action.Extent,
                                FMax = (float?)action.MaxDbl,
                                FMin = (float?)action.MinDbl,
                                //Frame = new global::Lifestoned.DataModel.Gdle.Frame
                                //{
                                //    Position = new global::Lifestoned.DataModel.Gdle.XYZ
                                //    {
                                //        X = action.OriginX ?? 0,
                                //        Y = action.OriginY ?? 0,
                                //        Z = action.OriginZ ?? 0
                                //    },
                                //    Rotations = new global::Lifestoned.DataModel.Gdle.Quaternion
                                //    {
                                //        W = action.AnglesW ?? 0,
                                //        X = action.AnglesX ?? 0,
                                //        Y = action.AnglesY ?? 0,
                                //        Z = action.AnglesZ ?? 0
                                //    }
                                //},
                                HeroXp64 = (ulong?)action.HeroXP64,
                                //Item = new global::Lifestoned.DataModel.Gdle.CreateItem
                                //{
                                //    Destination = (uint?)action.DestinationType,
                                //    Palette = (uint?)action.Palette,
                                //    Shade = action.Shade,
                                //    StackSize = action.StackSize,
                                //    TryToBond = Convert.ToByte(action.TryToBond),
                                //    WeenieClassId = action.WeenieClassId
                                //},
                                Max = (uint?)action.Max,
                                Min = (uint?)action.Min,
                                Maximum64 = action.Max64,
                                Minimum64 = action.Min64,
                                Message = action.Message,
                                Motion = (uint?)action.Motion,
                                //MPosition = new global::Lifestoned.DataModel.Gdle.Position
                                //{
                                //    LandCellId = action.ObjCellId ?? 0,
                                //    Frame = new global::Lifestoned.DataModel.Gdle.Frame
                                //    {
                                //        Position = new global::Lifestoned.DataModel.Gdle.XYZ
                                //        {
                                //            X = action.OriginX ?? 0,
                                //            Y = action.OriginY ?? 0,
                                //            Z = action.OriginZ ?? 0
                                //        },
                                //        Rotations = new global::Lifestoned.DataModel.Gdle.Quaternion
                                //        {
                                //            W = action.AnglesW ?? 0,
                                //            X = action.AnglesX ?? 0,
                                //            Y = action.AnglesY ?? 0,
                                //            Z = action.AnglesZ ?? 0
                                //        }
                                //    }
                                //},
                                Percent = (float?)action.Percent,
                                PScript = (uint?)action.PScript,
                                Sound = (uint?)action.Sound,
                                SpellId = (uint?)action.SpellId,
                                Stat = (uint?)action.Stat,
                                TestString = action.TestString,
                                TreasureClass = (uint?)action.TreasureClass,
                                WealthRating = (uint?)action.WealthRating,
                                TreasureType = action.TreasureType,
                            };

                            if (action.ObjCellId.HasValue)
                            {
                                ea.MPosition = new global::Lifestoned.DataModel.Gdle.Position
                                {
                                    LandCellId = action.ObjCellId ?? 0,
                                    Frame = new global::Lifestoned.DataModel.Gdle.Frame
                                    {
                                        Position = new global::Lifestoned.DataModel.Gdle.XYZ
                                        {
                                            X = action.OriginX ?? 0,
                                            Y = action.OriginY ?? 0,
                                            Z = action.OriginZ ?? 0
                                        },
                                        Rotations = new global::Lifestoned.DataModel.Gdle.Quaternion
                                        {
                                            W = action.AnglesW ?? 0,
                                            X = action.AnglesX ?? 0,
                                            Y = action.AnglesY ?? 0,
                                            Z = action.AnglesZ ?? 0
                                        }
                                    }
                                };
                            }
                            else if (action.OriginX.HasValue || action.OriginY.HasValue || action.OriginZ.HasValue || action.AnglesW.HasValue || action.AnglesX.HasValue || action.AnglesY.HasValue || action.AnglesZ.HasValue)
                            {
                                ea.Frame = new global::Lifestoned.DataModel.Gdle.Frame
                                {
                                    Position = new global::Lifestoned.DataModel.Gdle.XYZ
                                    {
                                        X = action.OriginX ?? 0,
                                        Y = action.OriginY ?? 0,
                                        Z = action.OriginZ ?? 0
                                    },
                                    Rotations = new global::Lifestoned.DataModel.Gdle.Quaternion
                                    {
                                        W = action.AnglesW ?? 0,
                                        X = action.AnglesX ?? 0,
                                        Y = action.AnglesY ?? 0,
                                        Z = action.AnglesZ ?? 0
                                    }
                                };
                            }

                            if (action.DestinationType.HasValue)
                            {
                                ea.Item = new global::Lifestoned.DataModel.Gdle.CreateItem
                                {
                                    Destination = (uint?)action.DestinationType,
                                    Palette = (uint?)action.Palette,
                                    Shade = action.Shade,
                                    StackSize = action.StackSize,
                                    TryToBond = Convert.ToByte(action.TryToBond),
                                    WeenieClassId = action.WeenieClassId
                                };
                            }

                            aorder++;

                            em.Actions.Add(ea);
                        }

                        ec.Emotes.Add(em);

                        var existingEC = result.EmoteTable.FirstOrDefault(e => e.EmoteCategoryId == (int)emote.Category);

                        if (existingEC == null)
                            result.EmoteTable.Add(ec);
                        else
                            existingEC.Emotes.Add(em);

                        eorder++;
                    }
                }

                // WeeniePropertiesEventFilter

                if (input.WeeniePropertiesFloat != null && input.WeeniePropertiesFloat.Count > 0)
                {
                    foreach (var value in input.WeeniePropertiesFloat)
                    {
                        if (result.FloatStats.FirstOrDefault(x => x.Key == value.Type) == null)
                            result.FloatStats.Add(new global::Lifestoned.DataModel.Gdle.FloatStat { Key = value.Type, Value = (float)value.Value });
                    }
                }

                if (input.WeeniePropertiesGenerator != null && input.WeeniePropertiesGenerator.Count > 0)
                {
                    result.GeneratorTable = new List<global::Lifestoned.DataModel.Gdle.GeneratorTable>();
                    uint slot = 0;
                    foreach (var value in input.WeeniePropertiesGenerator)
                    {
                        result.GeneratorTable.Add(new global::Lifestoned.DataModel.Gdle.GeneratorTable
                        {
                            Slot = slot,
                            Probability = value.Probability,
                            WeenieClassId = value.WeenieClassId,
                            Delay = value.Delay ?? 0,

                            InitCreate = (uint)value.InitCreate,
                            MaxNumber = (uint)value.MaxCreate,

                            WhenCreate = value.WhenCreate,
                            WhereCreate = value.WhereCreate,

                            StackSize = value.StackSize ?? 0,

                            PaletteId = value.PaletteId ?? 0,
                            Shade = value.Shade ?? 0,

                            ObjectCell = value.ObjCellId ?? 0,
                            Frame = new global::Lifestoned.DataModel.Gdle.Frame
                            {
                                Position = new global::Lifestoned.DataModel.Gdle.XYZ
                                {
                                    X = value.OriginX ?? 0,
                                    Y = value.OriginY ?? 0,
                                    Z = value.OriginZ ?? 0
                                },
                                Rotations = new global::Lifestoned.DataModel.Gdle.Quaternion
                                {
                                    W = value.AnglesW ?? 0,
                                    X = value.AnglesX ?? 0,
                                    Y = value.AnglesY ?? 0,
                                    Z = value.AnglesZ ?? 0
                                }
                            }
                        });
                        slot++;
                    }
                }

                if (input.WeeniePropertiesIID != null && input.WeeniePropertiesIID.Count > 0)
                {
                    result.IidStats = new List<global::Lifestoned.DataModel.Gdle.IidStat>();

                    foreach (var value in input.WeeniePropertiesIID)
                    {
                        if (result.IidStats.FirstOrDefault(x => x.Key == value.Type) == null)
                            result.IidStats.Add(new global::Lifestoned.DataModel.Gdle.IidStat { Key = value.Type, Value = (int)value.Value });
                    }
                }

                if (input.WeeniePropertiesInt != null && input.WeeniePropertiesInt.Count > 0)
                {
                    result.IntStats = new List<global::Lifestoned.DataModel.Gdle.IntStat>();

                    foreach (var value in input.WeeniePropertiesInt)
                    {
                        if (result.IntStats.FirstOrDefault(x => x.Key == value.Type) == null)
                            result.IntStats.Add(new global::Lifestoned.DataModel.Gdle.IntStat { Key = value.Type, Value = value.Value });
                    }
                }

                if (input.WeeniePropertiesInt64 != null && input.WeeniePropertiesInt64.Count > 0)
                {
                    result.Int64Stats = new List<global::Lifestoned.DataModel.Gdle.Int64Stat>();

                    foreach (var value in input.WeeniePropertiesInt64)
                    {
                        if (result.Int64Stats.FirstOrDefault(x => x.Key == value.Type) == null)
                            result.Int64Stats.Add(new global::Lifestoned.DataModel.Gdle.Int64Stat { Key = value.Type, Value = value.Value });
                    }
                }

                // WeeniePropertiesPalette

                if (input.WeeniePropertiesPosition != null && input.WeeniePropertiesPosition.Count > 0)
                {
                    result.Positions = new List<global::Lifestoned.DataModel.Gdle.PositionListing>();

                    foreach (var value in input.WeeniePropertiesPosition)
                    {
                        if (result.Positions.FirstOrDefault(x => x.PositionType == value.PositionType) == null)
                            result.Positions.Add(new global::Lifestoned.DataModel.Gdle.PositionListing
                            {
                                PositionType = value.PositionType,
                                Position = new global::Lifestoned.DataModel.Gdle.Position
                                {
                                    LandCellId = value.ObjCellId,
                                    Frame = new global::Lifestoned.DataModel.Gdle.Frame
                                    {
                                        Position = new global::Lifestoned.DataModel.Gdle.XYZ
                                        {
                                            X = value.OriginX,
                                            Y = value.OriginY,
                                            Z = value.OriginZ,
                                        },
                                        Rotations = new global::Lifestoned.DataModel.Gdle.Quaternion
                                        {
                                            W = value.AnglesW,
                                            X = value.AnglesX,
                                            Y = value.AnglesY,
                                            Z = value.AnglesZ
                                        }
                                    }
                                }
                            });
                    }
                }

                if (input.WeeniePropertiesSkill != null && input.WeeniePropertiesSkill.Count > 0)
                {
                    result.Skills = new List<global::Lifestoned.DataModel.Gdle.SkillListing>();

                    foreach (var value in input.WeeniePropertiesSkill)
                    {
                        if (result.Skills.FirstOrDefault(x => x.SkillId == value.Type) == null)
                            result.Skills.Add(new global::Lifestoned.DataModel.Gdle.SkillListing
                            {
                                SkillId = value.Type,
                                Skill = new global::Lifestoned.DataModel.Gdle.Skill
                                {
                                    LevelFromPp = value.LevelFromPP,
                                    TrainedLevel = (int)value.SAC,
                                    XpInvested = value.PP,
                                    Ranks = value.InitLevel,
                                    ResistanceOfLastCheck = value.ResistanceAtLastCheck,
                                    LastUsed = (float)value.LastUsedTime
                                }
                            });
                    }
                }

                if (input.WeeniePropertiesSpellBook != null && input.WeeniePropertiesSpellBook.Count > 0)
                {
                    result.Spells = new List<global::Lifestoned.DataModel.Gdle.SpellbookEntry>();

                    foreach (var value in input.WeeniePropertiesSpellBook)
                    {
                        if (result.Spells.FirstOrDefault(x => x.SpellId == value.Spell) == null)
                            result.Spells.Add(new global::Lifestoned.DataModel.Gdle.SpellbookEntry
                            {
                                SpellId = value.Spell,
                                Stats = new global::Lifestoned.DataModel.Gdle.SpellCastingStats
                                {
                                    CastingChance = value.Probability
                                }
                            });
                    }
                }

                if (input.WeeniePropertiesString != null && input.WeeniePropertiesString.Count > 0)
                {
                    result.StringStats = new List<global::Lifestoned.DataModel.Gdle.StringStat>();

                    foreach (var value in input.WeeniePropertiesString)
                    {
                        if (result.StringStats.FirstOrDefault(x => x.Key == value.Type) == null)
                            result.StringStats.Add(new global::Lifestoned.DataModel.Gdle.StringStat { Key = value.Type, Value = value.Value });
                    }
                }

                // WeeniePropertiesTextureMap

                result.Changelog = new List<global::Lifestoned.DataModel.Shared.ChangelogEntry>();
                result.Changelog.Add(new global::Lifestoned.DataModel.Shared.ChangelogEntry
                {
                    Author = "ACE.Adapter",
                    Comment = "Weenie exported from ACEmulator world database using ACE.Adapter",
                    Created = DateTime.UtcNow
                });

                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }

        public static JsonSerializerSettings SerializerSettings = new JsonSerializerSettings();

        static LifestonedConverter()
        {
            //SerializerSettings.Converters.Add(new JavaScriptDateTimeConverter());
            SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        }

        public static bool TryConvertACEWeenieToLSDJSON(Weenie weenie, out string result)
        {
            try
            {
                if (TryConvert(weenie, out var lsdWeenie))
                {
                    try
                    {
                        result = JsonConvert.SerializeObject(lsdWeenie, SerializerSettings);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        result = "serialize failed";
                        return false;
                    }
                    return true;
                }

                result = "try convert failed";
                return false;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
}
