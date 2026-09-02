using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200511C RID: 20764
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeInfo
	{
		// Token: 0x0603577D RID: 219005 RVA: 0x00D6B400 File Offset: 0x00D69600
		public RoguelikeInfo(RoguelikeInstInfo roguelikeInfo)
		{
			this.RoleEntry = new RogueGainEntry(roguelikeInfo.RoleEntry, null);
			if (roguelikeInfo.PhantomEntry != null)
			{
				this.PhantomEntry = new RogueGainEntry(roguelikeInfo.PhantomEntry, null);
			}
			this.BuffEntryList = new List<RogueGainEntry>();
			if (roguelikeInfo.BuffEntryList != null)
			{
				foreach (RogueGainEntry rogueGainEntry in roguelikeInfo.BuffEntryList)
				{
					this.BuffEntryList.Add(new RogueGainEntry(rogueGainEntry, null));
				}
			}
			this.ElementDict = new Dictionary<int, int>();
			if (roguelikeInfo.ElementDict != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in roguelikeInfo.ElementDict)
				{
					int value = keyValuePair.Value;
					if (value != 0)
					{
						this.ElementDict.Add(keyValuePair.Key, value);
					}
				}
			}
			this.SpecialEntryList = new List<RogueGainEntry>();
			if (roguelikeInfo.MiraclecreationList != null)
			{
				foreach (RogueGainEntry rogueGainEntry2 in roguelikeInfo.MiraclecreationList)
				{
					this.SpecialEntryList.Add(new RogueGainEntry(rogueGainEntry2, null));
				}
			}
		}

		// Token: 0x0603577E RID: 219006 RVA: 0x00D6B590 File Offset: 0x00D69790
		public void Update(RoguelikeGainDataUpdateNotify notify)
		{
			if (notify.GainDataUpdateType == GainDataUpdateType.GainDataUpdate)
			{
				if (notify.RogueGainEntry != null)
				{
					RoguelikeGainDataType type = notify.RogueGainEntry.Type;
					switch (type)
					{
					case RoguelikeGainDataType.Phantom:
						this.PhantomEntry = new RogueGainEntry(notify.RogueGainEntry, null);
						break;
					case RoguelikeGainDataType.Shop:
						break;
					case RoguelikeGainDataType.Role:
						this.RoleEntry = new RogueGainEntry(notify.RogueGainEntry, null);
						break;
					case RoguelikeGainDataType.CommonBuff:
					{
						int num = this.BuffEntryList.FindIndex((RogueGainEntry entry) => entry.IncId == notify.RogueGainEntry.IncId);
						if (num != -1)
						{
							this.BuffEntryList[num] = new RogueGainEntry(notify.RogueGainEntry, null);
						}
						break;
					}
					default:
						if (type == RoguelikeGainDataType.Miraclecreation)
						{
							int num2 = this.SpecialEntryList.FindIndex((RogueGainEntry entry) => entry.IncId == notify.RogueGainEntry.IncId);
							if (num2 != -1)
							{
								this.SpecialEntryList[num2] = new RogueGainEntry(notify.RogueGainEntry, null);
							}
						}
						break;
					}
				}
			}
			else if (notify.GainDataUpdateType == GainDataUpdateType.GainDataAdd)
			{
				if (notify.RogueGainEntry != null)
				{
					RoguelikeGainDataType type = notify.RogueGainEntry.Type;
					if (type != RoguelikeGainDataType.Phantom)
					{
						if (type != RoguelikeGainDataType.CommonBuff)
						{
							if (type == RoguelikeGainDataType.Miraclecreation)
							{
								this.SpecialEntryList.Add(new RogueGainEntry(notify.RogueGainEntry, null));
							}
						}
						else
						{
							this.BuffEntryList.Add(new RogueGainEntry(notify.RogueGainEntry, null));
						}
					}
					else
					{
						this.PhantomEntry = new RogueGainEntry(notify.RogueGainEntry, null);
					}
				}
			}
			else if (notify.GainDataUpdateType == GainDataUpdateType.GainDataDelete && notify.RogueGainEntry != null)
			{
				RoguelikeGainDataType type = notify.RogueGainEntry.Type;
				if (type != RoguelikeGainDataType.Phantom)
				{
					if (type != RoguelikeGainDataType.CommonBuff)
					{
						if (type == RoguelikeGainDataType.Miraclecreation)
						{
							int num3 = this.SpecialEntryList.FindIndex((RogueGainEntry entry) => entry.IncId == notify.RogueGainEntry.IncId);
							if (num3 != -1)
							{
								this.SpecialEntryList.RemoveAt(num3);
							}
						}
					}
					else
					{
						int num4 = this.BuffEntryList.FindIndex((RogueGainEntry entry) => entry.IncId == notify.RogueGainEntry.IncId);
						if (num4 != -1)
						{
							this.BuffEntryList.RemoveAt(num4);
						}
					}
				}
				else
				{
					this.PhantomEntry = null;
				}
			}
			this.ElementDict = new Dictionary<int, int>();
			if (notify.ElementDict != null)
			{
				foreach (KeyValuePair<int, int> keyValuePair in notify.ElementDict)
				{
					int value = keyValuePair.Value;
					if (value != 0)
					{
						this.ElementDict.Add(keyValuePair.Key, value);
					}
				}
			}
		}

		// Token: 0x0603577F RID: 219007 RVA: 0x00D6B8B8 File Offset: 0x00D69AB8
		public bool GetIsUnlock(AffixEntry affixEntry)
		{
			foreach (KeyValuePair<int, int> keyValuePair in affixEntry.ElementDict)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				int num = 0;
				int num2;
				if (this.ElementDict.TryGetValue(key, out num2))
				{
					num = num2;
				}
				if (num < value)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06035780 RID: 219008 RVA: 0x00D6B93C File Offset: 0x00D69B3C
		public float GetAttributeValue(int attrId)
		{
			if (this.AttributeDict.Count > 0)
			{
				int num;
				return (float)(this.AttributeDict.TryGetValue(attrId, out num) ? num : 0);
			}
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
			if (teamItems.Count <= 0)
			{
				return 0f;
			}
			RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(teamItems[0].GetConfigId, true);
			if (roleDataById == null)
			{
				return 0f;
			}
			return roleDataById.GetShowAttributeValueById(attrId);
		}

		// Token: 0x06035781 RID: 219009 RVA: 0x00D6B9B0 File Offset: 0x00D69BB0
		public List<AttrListScrollData> GetShowAttrList()
		{
			if (this.AttributeDict.Count > 0)
			{
				List<AttrListScrollData> list = new List<AttrListScrollData>();
				IReadOnlyList<PropertyIndex> propertyIndexList = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexList();
				if (propertyIndexList == null)
				{
					return list;
				}
				foreach (PropertyIndex propertyIndex in propertyIndexList)
				{
					if (propertyIndex.IsShow)
					{
						int num2;
						int num = this.AttributeDict.TryGetValue(propertyIndex.Id, out num2) ? num2 : 0;
						list.Add(new RoleAttrListScrollData(propertyIndex.Id, (double)num, 0.0, propertyIndex.Priority, false, CommonComponentDefine.EAttributeType.NormalType));
					}
				}
				list.Sort((AttrListScrollData a, AttrListScrollData b) => a.Priority - b.Priority);
				return list;
			}
			else
			{
				List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false);
				if (teamItems.Count <= 0)
				{
					return new List<AttrListScrollData>();
				}
				RoleDataBase roleDataById = ModelBase<RoleModel>.Instance.GetRoleDataById(teamItems[0].GetConfigId, true);
				if (roleDataById == null)
				{
					return new List<AttrListScrollData>();
				}
				return roleDataById.GetShowAttrList();
			}
		}

		// Token: 0x0401EBDB RID: 125915
		public RogueGainEntry RoleEntry;

		// Token: 0x0401EBDC RID: 125916
		[Nullable(2)]
		public RogueGainEntry PhantomEntry;

		// Token: 0x0401EBDD RID: 125917
		public List<RogueGainEntry> BuffEntryList;

		// Token: 0x0401EBDE RID: 125918
		public Dictionary<int, int> ElementDict;

		// Token: 0x0401EBDF RID: 125919
		public List<RogueGainEntry> SpecialEntryList;

		// Token: 0x0401EBE0 RID: 125920
		public Dictionary<int, int> AttributeDict = new Dictionary<int, int>();
	}
}
