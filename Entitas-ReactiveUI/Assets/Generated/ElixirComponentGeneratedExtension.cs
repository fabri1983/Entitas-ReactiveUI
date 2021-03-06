//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public ElixirComponent elixir { get { return (ElixirComponent)GetComponent(ComponentIds.Elixir); } }

        public bool hasElixir { get { return HasComponent(ComponentIds.Elixir); } }

        public Entity AddElixir(float newAmount) {
            var component = CreateComponent<ElixirComponent>(ComponentIds.Elixir);
            component.amount = newAmount;
            return AddComponent(ComponentIds.Elixir, component);
        }

        public Entity ReplaceElixir(float newAmount) {
            var component = CreateComponent<ElixirComponent>(ComponentIds.Elixir);
            component.amount = newAmount;
            ReplaceComponent(ComponentIds.Elixir, component);
            return this;
        }

        public Entity RemoveElixir() {
            return RemoveComponent(ComponentIds.Elixir);
        }
    }

    public partial class Pool {
        public Entity elixirEntity { get { return GetGroup(Matcher.Elixir).GetSingleEntity(); } }

        public ElixirComponent elixir { get { return elixirEntity.elixir; } }

        public bool hasElixir { get { return elixirEntity != null; } }

        public Entity SetElixir(float newAmount) {
            if (hasElixir) {
                throw new EntitasException("Could not set elixir!\n" + this + " already has an entity with ElixirComponent!",
                    "You should check if the pool already has a elixirEntity before setting it or use pool.ReplaceElixir().");
            }
            var entity = CreateEntity();
            entity.AddElixir(newAmount);
            return entity;
        }

        public Entity ReplaceElixir(float newAmount) {
            var entity = elixirEntity;
            if (entity == null) {
                entity = SetElixir(newAmount);
            } else {
                entity.ReplaceElixir(newAmount);
            }

            return entity;
        }

        public void RemoveElixir() {
            DestroyEntity(elixirEntity);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherElixir;

        public static IMatcher Elixir {
            get {
                if (_matcherElixir == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.Elixir);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherElixir = matcher;
                }

                return _matcherElixir;
            }
        }
    }
}
