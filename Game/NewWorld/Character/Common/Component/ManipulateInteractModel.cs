using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.SceneItem;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x02004905 RID: 18693
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class ManipulateInteractModel : ModelBase<ManipulateInteractModel>
	{
		// Token: 0x17008345 RID: 33605
		// (get) Token: 0x06030DAD RID: 200109 RVA: 0x00C19D29 File Offset: 0x00C17F29
		public double StatueInteractCheckAngle
		{
			get
			{
				return this.StatueInteractCheckAngleInternal;
			}
		}

		// Token: 0x17008346 RID: 33606
		// (get) Token: 0x06030DAE RID: 200110 RVA: 0x00C19D31 File Offset: 0x00C17F31
		public double StatueInteractMoveSpeed
		{
			get
			{
				return this.StatueInteractMoveSpeedInternal;
			}
		}

		// Token: 0x17008347 RID: 33607
		// (get) Token: 0x06030DAF RID: 200111 RVA: 0x00C19D39 File Offset: 0x00C17F39
		public double StatueInteractMaxMoveTime
		{
			get
			{
				return this.StatueInteractMaxMoveTimeInternal;
			}
		}

		// Token: 0x06030DB0 RID: 200112 RVA: 0x00C19D41 File Offset: 0x00C17F41
		protected override bool OnInit()
		{
			this.GetCommonValue();
			Singleton<EventSystem>.Instance.Add<bool, SceneItemExploreInteractComponent>(EEventName.OnOverlapSceneItemExploreInteractRange, new Action<bool, SceneItemExploreInteractComponent>(this.OnOverlapSceneItemExploreInteractRange));
			return true;
		}

		// Token: 0x06030DB1 RID: 200113 RVA: 0x00C19D68 File Offset: 0x00C17F68
		private void GetCommonValue()
		{
			GlobalConfigFromCsv? config = ConfigGlobalConfigFromCsvByName.GetConfig("StatueInteract.CheckAngle", true);
			if (config != null)
			{
				this.StatueInteractCheckAngleInternal = double.Parse(config.Value.Value);
			}
			config = ConfigGlobalConfigFromCsvByName.GetConfig("StatueInteract.MoveSpeed", true);
			if (config != null)
			{
				this.StatueInteractMoveSpeedInternal = (double)int.Parse(config.Value.Value);
			}
			config = ConfigGlobalConfigFromCsvByName.GetConfig("StatueInteract.MaxMoveTime", true);
			if (config != null)
			{
				this.StatueInteractMaxMoveTimeInternal = double.Parse(config.Value.Value);
			}
		}

		// Token: 0x06030DB2 RID: 200114 RVA: 0x00C19E03 File Offset: 0x00C18003
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove<bool, SceneItemExploreInteractComponent>(EEventName.OnOverlapSceneItemExploreInteractRange, new Action<bool, SceneItemExploreInteractComponent>(this.OnOverlapSceneItemExploreInteractRange));
			return true;
		}

		// Token: 0x06030DB3 RID: 200115 RVA: 0x00C19E24 File Offset: 0x00C18024
		private void OnOverlapSceneItemExploreInteractRange(bool isEnter, SceneItemExploreInteractComponent exploreInteractComp)
		{
			HashSet<SceneItemExploreInteractComponent> hashSet = exploreInteractComp.IsShootSwordInteractPoint ? this.ShootSwordInRangePoints : this.InRangePoints;
			if (isEnter)
			{
				hashSet.Add(exploreInteractComp);
				return;
			}
			hashSet.Remove(exploreInteractComp);
		}

		// Token: 0x0401C130 RID: 114992
		private double StatueInteractCheckAngleInternal = -1.0;

		// Token: 0x0401C131 RID: 114993
		private double StatueInteractMoveSpeedInternal = -1.0;

		// Token: 0x0401C132 RID: 114994
		private double StatueInteractMaxMoveTimeInternal = -1.0;

		// Token: 0x0401C133 RID: 114995
		public readonly HashSet<SceneItemExploreInteractComponent> InRangePoints = new HashSet<SceneItemExploreInteractComponent>();

		// Token: 0x0401C134 RID: 114996
		public readonly HashSet<SceneItemExploreInteractComponent> ShootSwordInRangePoints = new HashSet<SceneItemExploreInteractComponent>();
	}
}
