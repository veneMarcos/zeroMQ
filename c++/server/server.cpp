#include <string>
#include <zmq.hpp>

using namespace std;

int main()
{
   zmq::context_t ctx;
   zmq::socket_t sock(ctx, 8);
   sock.bind("inproc://test");
   const string_view m = "Hello, world";
   sock.send(zmq::buffer(m), zmq::send_flags::dontwait);
}