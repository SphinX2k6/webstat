using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Phantom.Vision.View
{
	// Token: 0x02004A6A RID: 19050
	[NullableContext(1)]
	[Nullable(0)]
	public class VisionDetailDesc
	{
		// Token: 0x06031BCB RID: 203723 RVA: 0x00C7419E File Offset: 0x00C7239E
		public void SetNeedCheckChangeColor(bool state)
		{
			this.NeedCheckChangeColor = state;
		}

		// Token: 0x06031BCC RID: 203724 RVA: 0x00C741A7 File Offset: 0x00C723A7
		public bool GetNeedCheckChangeColor()
		{
			return this.NeedCheckChangeColor;
		}

		// Token: 0x06031BCD RID: 203725 RVA: 0x00C741AF File Offset: 0x00C723AF
		public bool GetNeedWarn()
		{
			return this.EquipSameMonster || this.EquipOverNeed;
		}

		// Token: 0x06031BCE RID: 203726 RVA: 0x00C741C1 File Offset: 0x00C723C1
		public bool GetIsFetterData()
		{
			return this.FetterId > 0;
		}

		// Token: 0x06031BCF RID: 203727 RVA: 0x00C741CC File Offset: 0x00C723CC
		public static List<VisionDetailDesc> CreateEmptySkillDescData()
		{
			return new List<VisionDetailDesc>
			{
				new VisionDetailDesc
				{
					TitleItemShowState = true,
					Title = (ConfigMultiTextLang.GetLocalTextNew("VisionSkillTitle", null) ?? ""),
					EmptyState = true,
					EmptyText = (ConfigMultiTextLang.GetLocalTextNew("MainVisionEmpty", null) ?? ""),
					TitleType = 0
				}
			};
		}

		// Token: 0x06031BD0 RID: 203728 RVA: 0x00C74234 File Offset: 0x00C72434
		public static List<VisionDetailDesc> CreateEmptyFetterDescData()
		{
			return new List<VisionDetailDesc>
			{
				new VisionDetailDesc
				{
					TitleItemShowState = true,
					Title = (ConfigMultiTextLang.GetLocalTextNew("VisionFetterTitle", null) ?? ""),
					EmptyState = true,
					EmptyText = (ConfigMultiTextLang.GetLocalTextNew("FetterEmpty", null) ?? ""),
					TitleType = 1
				}
			};
		}

		// Token: 0x06031BD1 RID: 203729 RVA: 0x00C7429C File Offset: 0x00C7249C
		public static List<VisionDetailDesc> CreateSameMonsterTips()
		{
			return new List<VisionDetailDesc>
			{
				new VisionDetailDesc
				{
					Title = (ConfigMultiTextLang.GetLocalTextNew("VisionFetterTitle", null) ?? ""),
					EquipSameMonster = true,
					TitleItemShowState = false
				}
			};
		}

		// Token: 0x06031BD2 RID: 203730 RVA: 0x00C742E4 File Offset: 0x00C724E4
		public static List<VisionDetailDesc> CreateOverNeedTips()
		{
			return new List<VisionDetailDesc>
			{
				new VisionDetailDesc
				{
					Title = (ConfigMultiTextLang.GetLocalTextNew("VisionFetterTitle", null) ?? ""),
					EquipOverNeed = true,
					TitleItemShowState = false
				}
			};
		}

		// Token: 0x06031BD3 RID: 203731 RVA: 0x00C7432C File Offset: 0x00C7252C
		public static List<VisionDetailDesc> ConvertVisionSkillDescToDescData(PhantomSkill data, int level, bool ifMainPosition, bool ifPreview, int quality)
		{
			List<VisionDetailDesc> list = new List<VisionDetailDesc>();
			VisionDetailDesc visionDetailDesc = new VisionDetailDesc();
			visionDetailDesc.TitleItemShowState = true;
			visionDetailDesc.SkillConfig = new PhantomSkill?(data);
			visionDetailDesc.Level = level;
			visionDetailDesc.Quality = quality;
			visionDetailDesc.IfMainPosition = (ifMainPosition && !ifPreview);
			visionDetailDesc.NeedActiveState = true;
			if (ifMainPosition && !ifPreview)
			{
				visionDetailDesc.GreenActiveState = true;
			}
			else
			{
				visionDetailDesc.GreenActiveState = false;
			}
			if (data.IfCounterSkill)
			{
				visionDetailDesc.JumpCallBack = new Action(VisionDetailDesc.<ConvertVisionSkillDescToDescData>g__callback|32_0);
				visionDetailDesc.Title = (ConfigMultiTextLang.GetLocalTextNew("VisionCounterSkillText", null) ?? "");
			}
			else
			{
				visionDetailDesc.Title = (ConfigMultiTextLang.GetLocalTextNew("VisionSkillTitle", null) ?? "");
			}
			list.Add(visionDetailDesc);
			return list;
		}

		// Token: 0x06031BD4 RID: 203732 RVA: 0x00C743EC File Offset: 0x00C725EC
		public static List<VisionDetailDesc> ConvertVisionFetterDataToDetailDescData(List<VisionFetterData> data, bool ifEquipSameMonster, bool? ifEquipOverNeed = null, [Nullable(2)] Action jumpCallBack = null)
		{
			List<VisionDetailDesc> list = new List<VisionDetailDesc>();
			int count = data.Count;
			for (int i = 0; i < count; i++)
			{
				VisionDetailDesc visionDetailDesc = new VisionDetailDesc();
				if (i >= 1)
				{
					visionDetailDesc.TitleItemShowState = false;
				}
				visionDetailDesc.Title = (ConfigMultiTextLang.GetLocalTextNew("VisionFetterTitle", null) ?? "");
				visionDetailDesc.NeedActiveState = true;
				visionDetailDesc.NewState = data[i].NewAdd;
				visionDetailDesc.EquipSameMonster = ifEquipSameMonster;
				visionDetailDesc.EquipOverNeed = ifEquipOverNeed.GetValueOrDefault();
				if (data[i].ActiveState || data[i].NewAdd)
				{
					visionDetailDesc.GreenActiveState = true;
				}
				else
				{
					visionDetailDesc.GreenActiveState = false;
				}
				visionDetailDesc.FetterGroupId = data[i].FetterGroupId;
				visionDetailDesc.FetterId = data[i].FetterId;
				visionDetailDesc.FetterData = data[i];
				visionDetailDesc.JumpCallBack = jumpCallBack;
				list.Add(visionDetailDesc);
			}
			return list;
		}

		// Token: 0x06031BD6 RID: 203734 RVA: 0x00C7452C File Offset: 0x00C7272C
		[CompilerGenerated]
		internal static void <ConvertVisionSkillDescToDescData>g__callback|32_0()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(59);
		}

		// Token: 0x0401D1D8 RID: 119256
		public string Title = "";

		// Token: 0x0401D1D9 RID: 119257
		public bool TitleItemShowState = true;

		// Token: 0x0401D1DA RID: 119258
		[Nullable(2)]
		public Action JumpCallBack;

		// Token: 0x0401D1DB RID: 119259
		public bool NeedActiveState;

		// Token: 0x0401D1DC RID: 119260
		public bool GreenActiveState;

		// Token: 0x0401D1DD RID: 119261
		public bool NewState;

		// Token: 0x0401D1DE RID: 119262
		public int FetterId;

		// Token: 0x0401D1DF RID: 119263
		[Nullable(2)]
		public VisionFetterData FetterData;

		// Token: 0x0401D1E0 RID: 119264
		public bool IfMainPosition;

		// Token: 0x0401D1E1 RID: 119265
		public bool EmptyState;

		// Token: 0x0401D1E2 RID: 119266
		public string EmptyText = "";

		// Token: 0x0401D1E3 RID: 119267
		public string EmptyContentText = "";

		// Token: 0x0401D1E4 RID: 119268
		public PhantomSkill? SkillConfig;

		// Token: 0x0401D1E5 RID: 119269
		public int Level;

		// Token: 0x0401D1E6 RID: 119270
		public int FetterGroupId;

		// Token: 0x0401D1E7 RID: 119271
		private bool NeedCheckChangeColor = true;

		// Token: 0x0401D1E8 RID: 119272
		public bool DoNotNeedCheckSimplyState;

		// Token: 0x0401D1E9 RID: 119273
		public bool NeedSimplyStateChangeAnimation;

		// Token: 0x0401D1EA RID: 119274
		public bool AnimationState = true;

		// Token: 0x0401D1EB RID: 119275
		public int Quality;

		// Token: 0x0401D1EC RID: 119276
		public int TitleType = -1;

		// Token: 0x0401D1ED RID: 119277
		public bool EquipSameMonster;

		// Token: 0x0401D1EE RID: 119278
		public bool EquipOverNeed;

		// Token: 0x0401D1EF RID: 119279
		public bool CompareState;
	}
}
