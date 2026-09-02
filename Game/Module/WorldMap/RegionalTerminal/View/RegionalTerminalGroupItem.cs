using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.RegionalTerminal.View
{
	// Token: 0x02004BF2 RID: 19442
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RegionalTerminalGroupItem : GridProxyAbstract<RegionalTerminalGroupData>
	{
		// Token: 0x06032BAC RID: 207788 RVA: 0x00CB5400 File Offset: 0x00CB3600
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032BAD RID: 207789 RVA: 0x00CB5510 File Offset: 0x00CB3710
		protected override void OnStart()
		{
			this.LayoutGameplay = new GenericLayout<RegionalTerminalGameplayItem, RegionalTerminalGameplayData>(base.GetGridLayout(4), new Func<RegionalTerminalGameplayItem>(this.CreateGameplayItem), null, true, true);
			AUIBaseActor auibaseActor = base.GetGridLayout(4).GetOwner() as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnEventSequence));
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			base.GetItem(6).SetUIActive(false);
		}

		// Token: 0x06032BAE RID: 207790 RVA: 0x00CB5589 File Offset: 0x00CB3789
		private void OnEventSequence(string sequenceName, string eventName)
		{
			if (sequenceName == "Start" && eventName == "Start")
			{
				GenericLayout<RegionalTerminalGameplayItem, RegionalTerminalGameplayData> layoutGameplay = this.LayoutGameplay;
				if (layoutGameplay == null)
				{
					return;
				}
				layoutGameplay.PlayGridAnim();
			}
		}

		// Token: 0x06032BAF RID: 207791 RVA: 0x00CB55B8 File Offset: 0x00CB37B8
		public override UniTask RefreshAsync(RegionalTerminalGroupData data, bool isSelected, int gridIndex)
		{
			RegionalTerminalGroupItem.<RefreshAsync>d__10 <RefreshAsync>d__;
			<RefreshAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshAsync>d__.<>4__this = this;
			<RefreshAsync>d__.data = data;
			<RefreshAsync>d__.<>1__state = -1;
			<RefreshAsync>d__.<>t__builder.Start<RegionalTerminalGroupItem.<RefreshAsync>d__10>(ref <RefreshAsync>d__);
			return <RefreshAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06032BB0 RID: 207792 RVA: 0x00CB5603 File Offset: 0x00CB3803
		private RegionalTerminalGameplayItem CreateGameplayItem()
		{
			return new RegionalTerminalGameplayItem
			{
				OnClickToggleCallBack = new Action<bool, RegionalTerminalGameplayData>(this.OnClickToggle),
				IsToggleSelectOn = new Func<RegionalTerminalGameplayData, bool>(this.IsToggleSelectOn)
			};
		}

		// Token: 0x06032BB1 RID: 207793 RVA: 0x00CB5630 File Offset: 0x00CB3830
		public void RefreshFunctional()
		{
			foreach (RegionalTerminalGameplayItem regionalTerminalGameplayItem in this.LayoutGameplay.GetLayoutItemList())
			{
				regionalTerminalGameplayItem.RefreshFunctional();
			}
		}

		// Token: 0x06032BB2 RID: 207794 RVA: 0x00CB5688 File Offset: 0x00CB3888
		public void SetSelectOn(bool state)
		{
			if (this.IsSelectOn == state)
			{
				return;
			}
			this.IsSelectOn = state;
			base.GetItem(6).SetUIActive(state);
			if (state)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.PlayOrReplaySequenceByName("Select", false, null);
			}
		}

		// Token: 0x06032BB3 RID: 207795 RVA: 0x00CB56D5 File Offset: 0x00CB38D5
		[NullableContext(2)]
		public RegionalTerminalGameplayItem GetGameplayItem(int gameplayId)
		{
			return this.LayoutGameplay.GetLayoutItemByKey(gameplayId);
		}

		// Token: 0x06032BB4 RID: 207796 RVA: 0x00CB56E8 File Offset: 0x00CB38E8
		private void OnClickToggle(bool state, RegionalTerminalGameplayData data)
		{
			Action<bool, RegionalTerminalGameplayData, int> onClickToggleCallBack = this.OnClickToggleCallBack;
			if (onClickToggleCallBack == null)
			{
				return;
			}
			onClickToggleCallBack(state, data, this.Data.GroupId);
		}

		// Token: 0x06032BB5 RID: 207797 RVA: 0x00CB5707 File Offset: 0x00CB3907
		private bool IsToggleSelectOn(RegionalTerminalGameplayData data)
		{
			Func<RegionalTerminalGameplayData, bool> isToggleSelectOnCallBack = this.IsToggleSelectOnCallBack;
			return isToggleSelectOnCallBack != null && isToggleSelectOnCallBack(data);
		}

		// Token: 0x06032BB6 RID: 207798 RVA: 0x00CB571B File Offset: 0x00CB391B
		public override object GetKey(RegionalTerminalGroupData data, int displayIndex)
		{
			return data.GroupId;
		}

		// Token: 0x0401D870 RID: 120944
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401D871 RID: 120945
		[Nullable(2)]
		private RegionalTerminalGroupData Data;

		// Token: 0x0401D872 RID: 120946
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericLayout<RegionalTerminalGameplayItem, RegionalTerminalGameplayData> LayoutGameplay;

		// Token: 0x0401D873 RID: 120947
		private bool IsSelectOn;

		// Token: 0x0401D874 RID: 120948
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<bool, RegionalTerminalGameplayData, int> OnClickToggleCallBack;

		// Token: 0x0401D875 RID: 120949
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<RegionalTerminalGameplayData, bool> IsToggleSelectOnCallBack;

		// Token: 0x0200ACE2 RID: 44258
		[NullableContext(0)]
		public static class EComponents
		{
			// Token: 0x04035B31 RID: 219953
			public const int TexLogo = 0;

			// Token: 0x04035B32 RID: 219954
			public const int TexLogo2 = 1;

			// Token: 0x04035B33 RID: 219955
			public const int TxtName = 2;

			// Token: 0x04035B34 RID: 219956
			public const int SpriteName = 3;

			// Token: 0x04035B35 RID: 219957
			public const int LayoutGameplay = 4;

			// Token: 0x04035B36 RID: 219958
			public const int ItemGameplay = 5;

			// Token: 0x04035B37 RID: 219959
			public const int ItemSelectOn = 6;
		}
	}
}
