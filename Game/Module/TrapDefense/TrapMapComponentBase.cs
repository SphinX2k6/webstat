using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004DB5 RID: 19893
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class TrapMapComponentBase
	{
		// Token: 0x06033863 RID: 211043 RVA: 0x00CE3540 File Offset: 0x00CE1740
		public TrapMapComponentBase(TrapMapEntity parent)
		{
			this.Parent = parent;
		}

		// Token: 0x1700881A RID: 34842
		// (get) Token: 0x06033864 RID: 211044 RVA: 0x00CE354F File Offset: 0x00CE174F
		public TrapMapEntity Parent { get; }

		// Token: 0x06033865 RID: 211045 RVA: 0x00CE3557 File Offset: 0x00CE1757
		public static int GenComponentId()
		{
			TrapMapComponentBase.IncId++;
			return TrapMapComponentBase.IncId;
		}

		// Token: 0x1700881B RID: 34843
		// (get) Token: 0x06033866 RID: 211046 RVA: 0x00CE356A File Offset: 0x00CE176A
		// (set) Token: 0x06033867 RID: 211047 RVA: 0x00CE3585 File Offset: 0x00CE1785
		public int ComponentId
		{
			get
			{
				if (this.ComponentIdInternal == 0)
				{
					this.ComponentIdInternal = TrapMapComponentBase.GenComponentId();
				}
				return this.ComponentIdInternal;
			}
			set
			{
				this.ComponentIdInternal = value;
			}
		}

		// Token: 0x1700881C RID: 34844
		// (get) Token: 0x06033868 RID: 211048 RVA: 0x00CE358E File Offset: 0x00CE178E
		// (set) Token: 0x06033869 RID: 211049 RVA: 0x00CE3596 File Offset: 0x00CE1796
		public bool Enable
		{
			get
			{
				return this.EnableInner;
			}
			set
			{
				this.EnableInner = value;
				if (value)
				{
					if (this.FirstEnable)
					{
						this.FirstEnable = false;
						this.OnStart();
					}
					this.OnEnable();
					return;
				}
				this.OnDisable();
			}
		}

		// Token: 0x1700881D RID: 34845
		// (get) Token: 0x0603386A RID: 211050 RVA: 0x00CE35C4 File Offset: 0x00CE17C4
		// (set) Token: 0x0603386B RID: 211051 RVA: 0x00CE35CC File Offset: 0x00CE17CC
		public bool EnableTick
		{
			get
			{
				return this.EnableTickInner;
			}
			set
			{
				this.EnableTickInner = value;
			}
		}

		// Token: 0x0603386C RID: 211052 RVA: 0x00CE35D5 File Offset: 0x00CE17D5
		public void Init()
		{
			this.FirstEnable = true;
			this.OnInit();
		}

		// Token: 0x0603386D RID: 211053 RVA: 0x00CE35E4 File Offset: 0x00CE17E4
		public void Add()
		{
			this.OnAdd();
		}

		// Token: 0x0603386E RID: 211054 RVA: 0x00CE35EC File Offset: 0x00CE17EC
		public void Remove()
		{
			this.OnRemove();
		}

		// Token: 0x1700881E RID: 34846
		// (get) Token: 0x0603386F RID: 211055
		public abstract ETrapDefenseMapComponent ComponentType { get; }

		// Token: 0x06033870 RID: 211056 RVA: 0x00CE35F4 File Offset: 0x00CE17F4
		public void Tick(float delta)
		{
			if (this.Enable && this.EnableTick)
			{
				this.OnTick(delta);
			}
		}

		// Token: 0x06033871 RID: 211057 RVA: 0x00CE360D File Offset: 0x00CE180D
		protected virtual void OnAdd()
		{
		}

		// Token: 0x06033872 RID: 211058 RVA: 0x00CE360F File Offset: 0x00CE180F
		protected virtual void OnStart()
		{
		}

		// Token: 0x06033873 RID: 211059 RVA: 0x00CE3611 File Offset: 0x00CE1811
		protected virtual void OnEnable()
		{
		}

		// Token: 0x06033874 RID: 211060 RVA: 0x00CE3613 File Offset: 0x00CE1813
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x06033875 RID: 211061 RVA: 0x00CE3615 File Offset: 0x00CE1815
		protected virtual void OnDisable()
		{
		}

		// Token: 0x06033876 RID: 211062 RVA: 0x00CE3617 File Offset: 0x00CE1817
		protected virtual void OnRemove()
		{
		}

		// Token: 0x06033877 RID: 211063 RVA: 0x00CE3619 File Offset: 0x00CE1819
		protected virtual void OnInit()
		{
		}

		// Token: 0x0401DD5A RID: 122202
		[StaticVariableRuleIgnore]
		private static int IncId;

		// Token: 0x0401DD5B RID: 122203
		private bool EnableInner;

		// Token: 0x0401DD5C RID: 122204
		private bool FirstEnable;

		// Token: 0x0401DD5D RID: 122205
		private bool EnableTickInner;

		// Token: 0x0401DD5F RID: 122207
		private int ComponentIdInternal;
	}
}
