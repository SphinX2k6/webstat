using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Map.Base
{
	// Token: 0x020058F6 RID: 22774
	public abstract class MapEntity
	{
		// Token: 0x06039CDA RID: 236762 RVA: 0x00EA3C0B File Offset: 0x00EA1E0B
		public void Init()
		{
			this.OnInit();
			this.MapComponentContainer.Init();
		}

		// Token: 0x06039CDB RID: 236763 RVA: 0x00EA3C1E File Offset: 0x00EA1E1E
		public void Tick(float delta)
		{
			this.MapComponentContainer.Tick(delta);
			this.OnTick();
		}

		// Token: 0x06039CDC RID: 236764 RVA: 0x00EA3C32 File Offset: 0x00EA1E32
		public void Update()
		{
			this.MapComponentContainer.Update();
			this.OnUpdate();
		}

		// Token: 0x06039CDD RID: 236765 RVA: 0x00EA3C45 File Offset: 0x00EA1E45
		public void Dispose()
		{
			this.MapComponentContainer.RemoveAll();
			this.OnDispose();
		}

		// Token: 0x06039CDE RID: 236766 RVA: 0x00EA3C58 File Offset: 0x00EA1E58
		protected virtual void OnInit()
		{
		}

		// Token: 0x06039CDF RID: 236767 RVA: 0x00EA3C5A File Offset: 0x00EA1E5A
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06039CE0 RID: 236768 RVA: 0x00EA3C5C File Offset: 0x00EA1E5C
		protected virtual void OnTick()
		{
		}

		// Token: 0x06039CE1 RID: 236769 RVA: 0x00EA3C5E File Offset: 0x00EA1E5E
		protected virtual void OnDispose()
		{
		}

		// Token: 0x06039CE2 RID: 236770 RVA: 0x00EA3C60 File Offset: 0x00EA1E60
		[NullableContext(1)]
		public T AddComponent<[Nullable(0)] T>(EMapComponent componentType) where T : MapComponent
		{
			return this.MapComponentContainer.AddComponent<T>(componentType, new OneOf<MapComponent, MapComponentContainer, MapEntity>?(this));
		}

		// Token: 0x06039CE3 RID: 236771 RVA: 0x00EA3C79 File Offset: 0x00EA1E79
		[return: Nullable(2)]
		public T GetComponent<T>(EMapComponent componentType) where T : MapComponent
		{
			return this.MapComponentContainer.GetComponent<T>(componentType);
		}

		// Token: 0x06039CE4 RID: 236772 RVA: 0x00EA3C88 File Offset: 0x00EA1E88
		[NullableContext(1)]
		public T GetOrAddComponent<[Nullable(0)] T>(EMapComponent componentType) where T : MapComponent
		{
			T component = this.GetComponent<T>(componentType);
			if (component != null)
			{
				return component;
			}
			return this.AddComponent<T>(componentType);
		}

		// Token: 0x06039CE5 RID: 236773 RVA: 0x00EA3CAE File Offset: 0x00EA1EAE
		public void EnsureComponent<T>(EMapComponent componentType) where T : MapComponent
		{
			this.GetOrAddComponent<T>(componentType);
		}

		// Token: 0x06039CE6 RID: 236774 RVA: 0x00EA3CB8 File Offset: 0x00EA1EB8
		public void RemoveComponent(EMapComponent componentType)
		{
			this.MapComponentContainer.RemoveComponent(componentType);
		}

		// Token: 0x06039CE7 RID: 236775 RVA: 0x00EA3CC6 File Offset: 0x00EA1EC6
		public void ReloadComponent<T>(EMapComponent componentType) where T : MapComponent
		{
			this.RemoveComponent(componentType);
			this.AddComponent<T>(componentType);
		}

		// Token: 0x04020C1D RID: 134173
		[Nullable(1)]
		protected readonly MapComponentContainer MapComponentContainer = new MapComponentContainer();

		// Token: 0x04020C1E RID: 134174
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			0,
			1
		})]
		protected PropertyMap<OneOf<int, string>, OneOf<Vector2D, FVector2D, int>> PropertyMap = new PropertyMap<OneOf<int, string>, OneOf<Vector2D, FVector2D, int>>();
	}
}
