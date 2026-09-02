using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Map.Base;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Map.View.BaseMap;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.ViewComponent
{
	// Token: 0x02004B48 RID: 19272
	[NullableContext(2)]
	[Nullable(0)]
	public class WorldMapAlterMapComponent : MapComponent
	{
		// Token: 0x060324F1 RID: 206065 RVA: 0x00C9613B File Offset: 0x00C9433B
		public WorldMapAlterMapComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent) : base(parent)
		{
		}

		// Token: 0x1700864B RID: 34379
		// (get) Token: 0x060324F2 RID: 206066 RVA: 0x00C96144 File Offset: 0x00C94344
		public override EMapComponent ComponentType
		{
			get
			{
				return EMapComponent.WorldMapAlterMap;
			}
		}

		// Token: 0x1700864C RID: 34380
		// (get) Token: 0x060324F3 RID: 206067 RVA: 0x00C96148 File Offset: 0x00C94348
		private WorldMapUiEntity WorldMapUiComponent
		{
			get
			{
				WorldMapUiEntity worldMapUiEntity = base.Parent.AsT3 as WorldMapUiEntity;
				if (worldMapUiEntity == null)
				{
					base.LogError(ELogAuthor.LRX, "[地图系统]->二级界面组件没有附加到容器下！", default(ReadOnlySpan<ValueTuple<string, object>>));
					return null;
				}
				return worldMapUiEntity;
			}
		}

		// Token: 0x060324F4 RID: 206068 RVA: 0x00C96185 File Offset: 0x00C94385
		protected override void OnEnable()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x060324F5 RID: 206069 RVA: 0x00C961A3 File Offset: 0x00C943A3
		protected override void OnDisable()
		{
			this.CancelWaitSequence();
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivitySequenceEmitEvent, new Action<string>(this.OnActivitySequenceEmitEvent));
		}

		// Token: 0x060324F6 RID: 206070 RVA: 0x00C961C7 File Offset: 0x00C943C7
		private void CancelWaitSequence()
		{
			CustomPromise<bool> waitSequencePromise = this.WaitSequencePromise;
			if (waitSequencePromise != null)
			{
				waitSequencePromise.SetResult(false);
			}
			this.WaitSequencePromise = null;
		}

		// Token: 0x060324F7 RID: 206071 RVA: 0x00C961E4 File Offset: 0x00C943E4
		public UniTask ChangeMapAsync(int mapId, EMapGravityDirection? gravity = null)
		{
			WorldMapAlterMapComponent.<ChangeMapAsync>d__11 <ChangeMapAsync>d__;
			<ChangeMapAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ChangeMapAsync>d__.<>4__this = this;
			<ChangeMapAsync>d__.mapId = mapId;
			<ChangeMapAsync>d__.gravity = gravity;
			<ChangeMapAsync>d__.<>1__state = -1;
			<ChangeMapAsync>d__.<>t__builder.Start<WorldMapAlterMapComponent.<ChangeMapAsync>d__11>(ref <ChangeMapAsync>d__);
			return <ChangeMapAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060324F8 RID: 206072 RVA: 0x00C96237 File Offset: 0x00C94437
		[NullableContext(1)]
		private void OnActivitySequenceEmitEvent(string param)
		{
			if (param == "Invert")
			{
				CustomPromise<bool> waitSequencePromise = this.WaitSequencePromise;
				if (waitSequencePromise != null)
				{
					waitSequencePromise.SetResult(true);
				}
				this.WaitSequencePromise = null;
			}
		}

		// Token: 0x060324F9 RID: 206073 RVA: 0x00C96260 File Offset: 0x00C94460
		private UniTask ResolveChangeMap(int mapId, EMapGravityDirection? gravity)
		{
			WorldMapAlterMapComponent.<ResolveChangeMap>d__13 <ResolveChangeMap>d__;
			<ResolveChangeMap>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ResolveChangeMap>d__.<>4__this = this;
			<ResolveChangeMap>d__.mapId = mapId;
			<ResolveChangeMap>d__.gravity = gravity;
			<ResolveChangeMap>d__.<>1__state = -1;
			<ResolveChangeMap>d__.<>t__builder.Start<WorldMapAlterMapComponent.<ResolveChangeMap>d__13>(ref <ResolveChangeMap>d__);
			return <ResolveChangeMap>d__.<>t__builder.Task;
		}

		// Token: 0x060324FA RID: 206074 RVA: 0x00C962B4 File Offset: 0x00C944B4
		public void ChangeMapGravity()
		{
			EMapGravityDirection worldMapGravity = ModelBase<WorldMapModel>.Instance.WorldMapGravity;
			EMapGravityDirection value;
			if (worldMapGravity != EMapGravityDirection.Down)
			{
				if (worldMapGravity != EMapGravityDirection.Up)
				{
					return;
				}
				value = EMapGravityDirection.Down;
			}
			else
			{
				value = EMapGravityDirection.Up;
			}
			ModelBase<WorldMapModel>.Instance.WorldMapSelectGravity = new EMapGravityDirection?(value);
			BaseMap map = this.WorldMapUiComponent.Map;
			this.ChangeMapAsync(map.MapId, new EMapGravityDirection?(ModelBase<WorldMapModel>.Instance.WorldMapGravity)).Forget();
		}

		// Token: 0x1700864D RID: 34381
		// (get) Token: 0x060324FB RID: 206075 RVA: 0x00C9631C File Offset: 0x00C9451C
		public bool CanChangeMapGravity
		{
			get
			{
				int mapId = this.WorldMapUiComponent.Map.MapId;
				return ModelBase<WorldMapModel>.Instance.IsGravityMap(mapId);
			}
		}

		// Token: 0x060324FC RID: 206076 RVA: 0x00C96348 File Offset: 0x00C94548
		protected override void OnRemove()
		{
			ModelBase<WorldMapModel>.Instance.WorldMapSelectGravity = null;
		}

		// Token: 0x0401D65E RID: 120414
		public TWorldMapPlaySequenceFunction WorldMapViewPlaySequenceFunction;

		// Token: 0x0401D65F RID: 120415
		public UUIItem InverseTowerCtrlRoot;

		// Token: 0x0401D660 RID: 120416
		private CustomPromise<bool> WaitSequencePromise;
	}
}
