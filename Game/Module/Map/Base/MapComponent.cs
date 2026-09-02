using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.Misc;

namespace CSharpScript.Game.Module.Map.Base
{
	// Token: 0x020058F4 RID: 22772
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MapComponent : IStaticVariableResetter
	{
		// Token: 0x06039CAF RID: 236719 RVA: 0x00EA3573 File Offset: 0x00EA1773
		static MapComponent()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MapComponent.CreateStaticDefaultValue), new Action(MapComponent.ResetStaticDefaultValue));
		}

		// Token: 0x06039CB0 RID: 236720 RVA: 0x00EA3592 File Offset: 0x00EA1792
		public static int GenComponentId()
		{
			MapComponent.IncId++;
			return MapComponent.IncId;
		}

		// Token: 0x170093C1 RID: 37825
		// (get) Token: 0x06039CB1 RID: 236721 RVA: 0x00EA35A5 File Offset: 0x00EA17A5
		// (set) Token: 0x06039CB2 RID: 236722 RVA: 0x00EA35C0 File Offset: 0x00EA17C0
		public int ComponentId
		{
			get
			{
				if (this.ComponentIdInternal == 0)
				{
					this.ComponentIdInternal = MapComponent.GenComponentId();
				}
				return this.ComponentIdInternal;
			}
			set
			{
				this.ComponentIdInternal = value;
			}
		}

		// Token: 0x170093C2 RID: 37826
		// (get) Token: 0x06039CB3 RID: 236723 RVA: 0x00EA35C9 File Offset: 0x00EA17C9
		// (set) Token: 0x06039CB4 RID: 236724 RVA: 0x00EA35D1 File Offset: 0x00EA17D1
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public OneOf<MapComponent, MapComponentContainer, MapEntity> Parent { [return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] set; }

		// Token: 0x06039CB5 RID: 236725 RVA: 0x00EA35DA File Offset: 0x00EA17DA
		public MapComponent([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<MapComponent, MapComponentContainer, MapEntity> parent)
		{
			this.Parent = parent;
		}

		// Token: 0x170093C3 RID: 37827
		// (get) Token: 0x06039CB6 RID: 236726 RVA: 0x00EA35F4 File Offset: 0x00EA17F4
		public MapEntity ParentEntity
		{
			get
			{
				return this.Parent.AsT3;
			}
		}

		// Token: 0x170093C4 RID: 37828
		// (get) Token: 0x06039CB7 RID: 236727 RVA: 0x00EA3610 File Offset: 0x00EA1810
		// (set) Token: 0x06039CB8 RID: 236728 RVA: 0x00EA3644 File Offset: 0x00EA1844
		public bool Enable
		{
			get
			{
				return this.PropertyMap.TryGet("Enable", false, true).AsT2;
			}
			set
			{
				this.PropertyMap.Set("Enable", value);
				if (!this.PropertyMap.IsDirty("Enable"))
				{
					return;
				}
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

		// Token: 0x170093C5 RID: 37829
		// (get) Token: 0x06039CB9 RID: 236729 RVA: 0x00EA36AC File Offset: 0x00EA18AC
		// (set) Token: 0x06039CBA RID: 236730 RVA: 0x00EA36DD File Offset: 0x00EA18DD
		private bool FirstEnable
		{
			get
			{
				return this.PropertyMap.TryGet("FirstEnable", true, true).AsT2;
			}
			set
			{
				this.PropertyMap.Set("FirstEnable", value);
			}
		}

		// Token: 0x170093C6 RID: 37830
		// (get) Token: 0x06039CBB RID: 236731 RVA: 0x00EA36FC File Offset: 0x00EA18FC
		// (set) Token: 0x06039CBC RID: 236732 RVA: 0x00EA372D File Offset: 0x00EA192D
		public bool EnableTick
		{
			get
			{
				return this.PropertyMap.TryGet("EnableTick", false, true).AsT2;
			}
			private set
			{
				this.PropertyMap.Set("EnableTick", value);
			}
		}

		// Token: 0x06039CBD RID: 236733 RVA: 0x00EA374B File Offset: 0x00EA194B
		public void Remove()
		{
			this.OnRemove();
		}

		// Token: 0x06039CBE RID: 236734 RVA: 0x00EA3753 File Offset: 0x00EA1953
		protected virtual void OnRemove()
		{
		}

		// Token: 0x06039CBF RID: 236735 RVA: 0x00EA3755 File Offset: 0x00EA1955
		public void Add()
		{
			this.OnAdd();
		}

		// Token: 0x06039CC0 RID: 236736 RVA: 0x00EA375D File Offset: 0x00EA195D
		protected virtual void OnAdd()
		{
		}

		// Token: 0x06039CC1 RID: 236737 RVA: 0x00EA375F File Offset: 0x00EA195F
		protected virtual void OnEnable()
		{
		}

		// Token: 0x06039CC2 RID: 236738 RVA: 0x00EA3761 File Offset: 0x00EA1961
		protected virtual void OnStart()
		{
		}

		// Token: 0x06039CC3 RID: 236739 RVA: 0x00EA3763 File Offset: 0x00EA1963
		protected virtual void OnDisable()
		{
		}

		// Token: 0x170093C7 RID: 37831
		// (get) Token: 0x06039CC4 RID: 236740
		public abstract EMapComponent ComponentType { get; }

		// Token: 0x06039CC5 RID: 236741 RVA: 0x00EA3765 File Offset: 0x00EA1965
		public void Init()
		{
			this.OnInit();
		}

		// Token: 0x06039CC6 RID: 236742 RVA: 0x00EA376D File Offset: 0x00EA196D
		protected virtual void OnInit()
		{
		}

		// Token: 0x06039CC7 RID: 236743 RVA: 0x00EA376F File Offset: 0x00EA196F
		public void Tick(float delta)
		{
			if (this.Enable && this.EnableTick)
			{
				this.OnTick(delta);
			}
		}

		// Token: 0x06039CC8 RID: 236744 RVA: 0x00EA3788 File Offset: 0x00EA1988
		protected virtual void OnTick(float delta)
		{
		}

		// Token: 0x06039CC9 RID: 236745 RVA: 0x00EA378A File Offset: 0x00EA198A
		public void Update()
		{
			if (this.Enable)
			{
				this.OnUpdate();
			}
		}

		// Token: 0x06039CCA RID: 236746 RVA: 0x00EA379A File Offset: 0x00EA199A
		protected virtual void OnUpdate()
		{
		}

		// Token: 0x06039CCB RID: 236747 RVA: 0x00EA379C File Offset: 0x00EA199C
		protected void LogInfo(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			MapLogger.Info(author, message, pairs);
		}

		// Token: 0x06039CCC RID: 236748 RVA: 0x00EA37A6 File Offset: 0x00EA19A6
		protected void LogWarn(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			MapLogger.Warn(author, message, pairs);
		}

		// Token: 0x06039CCD RID: 236749 RVA: 0x00EA37B0 File Offset: 0x00EA19B0
		protected void LogError(ELogAuthor author, string message, [ParamCollection] [ScopedRef] [Nullable(new byte[]
		{
			0,
			0,
			1,
			2
		})] ReadOnlySpan<ValueTuple<string, object>> pairs)
		{
			MapLogger.Error(author, message, pairs);
		}

		// Token: 0x06039CCE RID: 236750 RVA: 0x00EA37BA File Offset: 0x00EA19BA
		public static void CreateStaticDefaultValue()
		{
			MapComponent.IncId = 0;
		}

		// Token: 0x06039CCF RID: 236751 RVA: 0x00EA37C2 File Offset: 0x00EA19C2
		public static void ResetStaticDefaultValue()
		{
			MapComponent.IncId = 0;
		}

		// Token: 0x04020C15 RID: 134165
		[Nullable(new byte[]
		{
			1,
			0,
			1,
			0,
			1,
			1
		})]
		protected PropertyMap<OneOf<int, string>, OneOf<Vector2D, bool, int, string, float>> PropertyMap = new PropertyMap<OneOf<int, string>, OneOf<Vector2D, bool, int, string, float>>();

		// Token: 0x04020C16 RID: 134166
		private static int IncId;

		// Token: 0x04020C17 RID: 134167
		private int ComponentIdInternal;
	}
}
