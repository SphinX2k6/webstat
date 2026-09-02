using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x020060A9 RID: 24745
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleSpecialEnergyBar
	{
		// Token: 0x0603E78E RID: 255886 RVA: 0x00FF7544 File Offset: 0x00FF5744
		public UniTask InitAsync(UUIItem parentItem, BattleUiRoleData roleData)
		{
			RoleSpecialEnergyBar.<InitAsync>d__6 <InitAsync>d__;
			<InitAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAsync>d__.<>4__this = this;
			<InitAsync>d__.parentItem = parentItem;
			<InitAsync>d__.roleData = roleData;
			<InitAsync>d__.<>1__state = -1;
			<InitAsync>d__.<>t__builder.Start<RoleSpecialEnergyBar.<InitAsync>d__6>(ref <InitAsync>d__);
			return <InitAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E78F RID: 255887 RVA: 0x00FF7598 File Offset: 0x00FF5798
		public void SetVisible(bool visible)
		{
			foreach (SpecialEnergyBarBase specialEnergyBarBase in this.EnergyBarMap.Values)
			{
				specialEnergyBarBase.SetVisible(visible, 0);
			}
		}

		// Token: 0x0603E790 RID: 255888 RVA: 0x00FF75F0 File Offset: 0x00FF57F0
		public void Destroy()
		{
			this.ClearAllTagCountChangedCallback();
			foreach (SpecialEnergyBarBase specialEnergyBarBase in this.EnergyBarMap.Values)
			{
				specialEnergyBarBase.Destroy(null);
			}
			this.EnergyBarMap.Clear();
		}

		// Token: 0x0603E791 RID: 255889 RVA: 0x00FF7658 File Offset: 0x00FF5858
		public void Tick(float delta)
		{
			foreach (SpecialEnergyBarBase specialEnergyBarBase in this.EnergyBarMap.Values)
			{
				specialEnergyBarBase.Tick(delta);
			}
		}

		// Token: 0x0603E792 RID: 255890 RVA: 0x00FF76B0 File Offset: 0x00FF58B0
		[NullableContext(2)]
		private SpecialEnergyBarInfo GetSpecialEnergyBarConfigByRoleData(BattleUiRoleData roleData)
		{
			bool flag;
			if (roleData == null)
			{
				flag = true;
			}
			else
			{
				EntityHandle entityHandle = roleData.EntityHandle;
				flag = !((entityHandle != null) ? new bool?(entityHandle.Valid) : null).GetValueOrDefault();
			}
			if (flag)
			{
				return null;
			}
			RoleInfo? roleConfig = roleData.RoleConfig;
			if (roleConfig == null)
			{
				return null;
			}
			int specialEnergyBarId = roleConfig.Value.SpecialEnergyBarId;
			if (specialEnergyBarId == 0)
			{
				return null;
			}
			return ModelBase<BattleUiModel>.Instance.SpecialEnergyBarData.GetSpecialEnergyBarInfo(specialEnergyBarId);
		}

		// Token: 0x0603E793 RID: 255891 RVA: 0x00FF7728 File Offset: 0x00FF5928
		private UniTask LoadByConfig(UUIItem parentItem, BattleUiRoleData roleData, int tagId, SpecialEnergyBarInfo config)
		{
			RoleSpecialEnergyBar.<LoadByConfig>d__11 <LoadByConfig>d__;
			<LoadByConfig>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadByConfig>d__.<>4__this = this;
			<LoadByConfig>d__.parentItem = parentItem;
			<LoadByConfig>d__.roleData = roleData;
			<LoadByConfig>d__.tagId = tagId;
			<LoadByConfig>d__.config = config;
			<LoadByConfig>d__.<>1__state = -1;
			<LoadByConfig>d__.<>t__builder.Start<RoleSpecialEnergyBar.<LoadByConfig>d__11>(ref <LoadByConfig>d__);
			return <LoadByConfig>d__.<>t__builder.Task;
		}

		// Token: 0x0603E794 RID: 255892 RVA: 0x00FF778C File Offset: 0x00FF598C
		private void OnTagChange(int tagId, bool tagExists)
		{
			this.RefreshVisibleByTag(true);
		}

		// Token: 0x0603E795 RID: 255893 RVA: 0x00FF7798 File Offset: 0x00FF5998
		private void RefreshVisibleByTag(bool isTagChange = false)
		{
			if (this.EnergyBarMap.Count > 1)
			{
				BattleUiRoleData roleData = this.RoleData;
				BaseTagComponent baseTagComponent = (roleData != null) ? roleData.GameplayTagComponent : null;
				int num = 0;
				foreach (int num2 in this.EnergyBarMap.Keys)
				{
					if (num2 != 0 && baseTagComponent != null && baseTagComponent.HasTag(num2))
					{
						num = num2;
						break;
					}
				}
				foreach (KeyValuePair<int, SpecialEnergyBarBase> keyValuePair in this.EnergyBarMap)
				{
					int num3;
					SpecialEnergyBarBase specialEnergyBarBase;
					keyValuePair.Deconstruct(out num3, out specialEnergyBarBase);
					int num4 = num3;
					SpecialEnergyBarBase specialEnergyBarBase2 = specialEnergyBarBase;
					bool flag = num4 == num;
					specialEnergyBarBase2.SetVisible(flag, 1);
					if (isTagChange)
					{
						specialEnergyBarBase2.OnChangeVisibleByTagChange(flag);
					}
				}
				return;
			}
			SpecialEnergyBarBase valueOrDefault = this.EnergyBarMap.GetValueOrDefault(0);
			if (valueOrDefault == null)
			{
				return;
			}
			valueOrDefault.SetVisible(true, 1);
		}

		// Token: 0x0603E796 RID: 255894 RVA: 0x00FF78A4 File Offset: 0x00FF5AA4
		private void ListenForTagAddOrRemove(int tagId, BaseTagComponent.TTagSwitchedCallback onTagChange)
		{
			BattleUiRoleData roleData = this.RoleData;
			ITagTask tagTask;
			if (roleData == null)
			{
				tagTask = null;
			}
			else
			{
				BaseTagComponent gameplayTagComponent = roleData.GameplayTagComponent;
				tagTask = ((gameplayTagComponent != null) ? gameplayTagComponent.ListenForTagAddOrRemove(new int?(tagId), onTagChange, null) : null);
			}
			ITagTask tagTask2 = tagTask;
			if (tagTask2 != null)
			{
				this.TagTaskList.Add(tagTask2);
			}
		}

		// Token: 0x0603E797 RID: 255895 RVA: 0x00FF78E8 File Offset: 0x00FF5AE8
		private void ClearAllTagCountChangedCallback()
		{
			foreach (ITagTask tagTask in this.TagTaskList)
			{
				tagTask.EndTask();
			}
			this.TagTaskList.Clear();
		}

		// Token: 0x04023047 RID: 143431
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<int, Type> SpecialEnergyBarClassMap = new Dictionary<int, Type>
		{
			{
				11,
				typeof(SpecialEnergyBarChun)
			},
			{
				150402,
				typeof(SpecialEnergyBarDengDeng)
			},
			{
				110701,
				typeof(SpecialEnergyBarKeLaiTa)
			},
			{
				110702,
				typeof(SpecialEnergyBarKeLaiTaUltra)
			},
			{
				160600,
				typeof(SpecialEnergyBarLuoKeKe)
			},
			{
				120600,
				typeof(SpecialEnergyBarBuLanTe)
			},
			{
				150601,
				typeof(SpecialEnergyBarFeibi)
			},
			{
				160700,
				typeof(SpecialEnergyBarKanTeLeiLa)
			},
			{
				140600,
				typeof(SpecialEnergyBarWind)
			},
			{
				140700,
				typeof(SpecialEnergyBarXiaKong)
			},
			{
				150700,
				typeof(SpecialEnergyBarZanni)
			},
			{
				120700,
				typeof(SpecialEnergyBarLuPa)
			},
			{
				140900,
				typeof(SpecialEnergyBarKaTiXiYa)
			},
			{
				502100,
				typeof(SpecialEnergyBarMorphPlayUse)
			},
			{
				160800,
				typeof(SpecialEnergyBarFuLuoLuo)
			},
			{
				141000,
				typeof(SpecialEnergyBarYouNuo)
			},
			{
				130600,
				typeof(SpecialEnergyBarAoGuSiTa)
			},
			{
				141100,
				typeof(SpecialEnergyBarQiuYuan)
			},
			{
				120800,
				typeof(SpecialEnergyBarJiaBeiLiNa)
			},
			{
				130700,
				typeof(SpecialEnergyBarBuLing)
			},
			{
				121000,
				typeof(SpecialEnergyBarAiMiSi)
			},
			{
				150800,
				typeof(SpecialEnergyBarQianXiao)
			},
			{
				120900,
				typeof(SpecialEnergyBarMoNing)
			},
			{
				150900,
				typeof(SpecialEnergyBarLinNai)
			},
			{
				151001,
				typeof(SpecialEnergyBarLuhes)
			},
			{
				151100,
				typeof(SpecialEnergyBarLuXi)
			},
			{
				110801,
				typeof(SpecialEnergyBarFeiXue)
			},
			{
				110901,
				typeof(SpecialEnergyBarLuosela)
			},
			{
				800400,
				typeof(SpecialEnergyBarSuizhe)
			},
			{
				121101,
				typeof(SpecialEnergyBarDaniya)
			},
			{
				130800,
				typeof(SpecialEnergyBarRuibeika)
			},
			{
				141200,
				typeof(SpecialEnergyBarXigelika)
			},
			{
				130900,
				typeof(SpecialEnergyBarThunder)
			},
			{
				161001,
				typeof(SpecialEnergyBarXuanling)
			},
			{
				111001,
				typeof(SpecialEnergyBarSuisui)
			},
			{
				141300,
				typeof(SpecialEnergyBarQingXiao)
			},
			{
				121201,
				typeof(SpecialEnergyBarJingRan)
			}
		};

		// Token: 0x04023048 RID: 143432
		[StaticVariableRuleIgnore]
		private static readonly Type[] SpecialEnergyBarClassList = new Type[]
		{
			typeof(SpecialEnergyBarPoint),
			typeof(SpecialEnergyBarSlot),
			typeof(SpecialEnergyBarPointGraduate),
			typeof(SpecialEnergyBarMorph),
			typeof(SpecialEnergyBarMorph),
			typeof(SpecialEnergyBarMorphCountDown),
			typeof(SpecialEnergyBarJianXin),
			typeof(SpecialEnergyBarSanHua),
			typeof(SpecialEnergyBarChiXia),
			typeof(SpecialEnergyBarMorphCountDown),
			typeof(SpecialEnergyBarMorphJinXi),
			typeof(SpecialEnergyBarXiangLiYao),
			typeof(SpecialEnergyBarZheZhi)
		};

		// Token: 0x04023049 RID: 143433
		[Nullable(2)]
		private BattleUiRoleData RoleData;

		// Token: 0x0402304A RID: 143434
		private readonly Dictionary<int, SpecialEnergyBarBase> EnergyBarMap = new Dictionary<int, SpecialEnergyBarBase>();

		// Token: 0x0402304B RID: 143435
		private readonly List<ITagTask> TagTaskList = new List<ITagTask>();

		// Token: 0x0200C1BE RID: 49598
		[NullableContext(0)]
		private enum EVisibleReason
		{
			// Token: 0x0403BA62 RID: 244322
			Role,
			// Token: 0x0403BA63 RID: 244323
			Tag
		}
	}
}
