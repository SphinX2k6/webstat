using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB1 RID: 19889
	public class TrapMapEntity
	{
		// Token: 0x06033851 RID: 211025 RVA: 0x00CE3442 File Offset: 0x00CE1642
		public void Init()
		{
			this.OnInit();
			this.MapComponentContainer.Init();
		}

		// Token: 0x06033852 RID: 211026 RVA: 0x00CE3455 File Offset: 0x00CE1655
		public void Tick(float delta)
		{
			this.MapComponentContainer.Tick(delta);
			this.OnTick();
		}

		// Token: 0x06033853 RID: 211027 RVA: 0x00CE3469 File Offset: 0x00CE1669
		public void Dispose()
		{
			this.MapComponentContainer.RemoveAll();
			this.OnDispose();
		}

		// Token: 0x06033854 RID: 211028 RVA: 0x00CE347C File Offset: 0x00CE167C
		protected virtual void OnInit()
		{
		}

		// Token: 0x06033855 RID: 211029 RVA: 0x00CE347E File Offset: 0x00CE167E
		protected virtual void OnTick()
		{
		}

		// Token: 0x06033856 RID: 211030 RVA: 0x00CE3480 File Offset: 0x00CE1680
		protected virtual void OnDispose()
		{
		}

		// Token: 0x06033857 RID: 211031 RVA: 0x00CE3482 File Offset: 0x00CE1682
		[return: Nullable(2)]
		public T AddComponent<T>(ETrapDefenseMapComponent componentType) where T : TrapMapComponentBase
		{
			return this.MapComponentContainer.AddComponent(componentType, this) as T;
		}

		// Token: 0x06033858 RID: 211032 RVA: 0x00CE349B File Offset: 0x00CE169B
		[return: Nullable(2)]
		public T GetComponent<T>(ETrapDefenseMapComponent componentType) where T : TrapMapComponentBase
		{
			return this.MapComponentContainer.GetComponent<T>(componentType);
		}

		// Token: 0x06033859 RID: 211033 RVA: 0x00CE34A9 File Offset: 0x00CE16A9
		public void RemoveComponent(ETrapDefenseMapComponent componentType)
		{
			this.MapComponentContainer.RemoveComponent(componentType);
		}

		// Token: 0x0401DD59 RID: 122201
		[Nullable(1)]
		protected readonly TrapMapComponentContainer MapComponentContainer = new TrapMapComponentContainer();
	}
}
